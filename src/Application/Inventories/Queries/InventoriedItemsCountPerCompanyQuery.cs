using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Application.Common.Exceptions;
using Products.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Products.Application.Inventories.Queries
{
    public class InventoriedItemsCountPerCompanyQueryResponse
    {
        public string CompanyPrefix { get; set; }
        public string CompanyName { get; set; }
        public long InventoriedItemsCount { get; set; }
    }

    public class InventoriedItemsCountPerCompanyQuery : IRequest<InventoriedItemsCountPerCompanyQueryResponse>
    {
        public InventoriedItemsCountPerCompanyQuery(string companyPrefix)
        {
            CompanyPrefix = companyPrefix;
        }

        public string CompanyPrefix { get; }
    }

    public class InventoriedItemsCountPerCompanyQueryHandler : IRequestHandler<InventoriedItemsCountPerCompanyQuery, InventoriedItemsCountPerCompanyQueryResponse>
    {
        private readonly IApplicationDbContext _context;

        public InventoriedItemsCountPerCompanyQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<InventoriedItemsCountPerCompanyQueryResponse> Handle(InventoriedItemsCountPerCompanyQuery query, CancellationToken cancellationToken)
        {
            var res = await _context.InventoryItems
                .Join(
                    _context.Products,
                    inventoryItem => new { inventoryItem.CompanyPrefix, inventoryItem.ItemReference },
                    product => new { product.CompanyPrefix, product.ItemReference },
                    (inventoryItem, product) => new
                    {
                        product.CompanyPrefix,
                        product.CompanyName,
                        InventoryItem = inventoryItem
                    }
                )
                .GroupBy(i => new { i.CompanyPrefix, i.CompanyName }, (key, g) => new InventoriedItemsCountPerCompanyQueryResponse
                {
                    CompanyPrefix = key.CompanyPrefix,
                    CompanyName = key.CompanyName,
                    InventoriedItemsCount = g.LongCount()
                })
                .Where(t => t.CompanyPrefix == query.CompanyPrefix)
                .FirstOrDefaultAsync(cancellationToken);

            if (res == null)
            {
                throw new NotFoundException($"Company with Company Prefix '{query.CompanyPrefix}' not found");
            }

            return res;
        }
    }
}
