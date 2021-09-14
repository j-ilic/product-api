using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Application.Common.Exceptions;
using Products.Application.Common.Interfaces;
using Products.Application.Specifications;
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

    public class InventoriedItemsCountPerCompanyQuery : IRequest<IPageableCollection<InventoriedItemsCountPerCompanyQueryResponse>>
    {
        public InventoriedItemsCountPerCompanyQuery(InventoriedItemsSpecification specification, int skip = 0, int take = 25)
        {
            Specification = specification;
            Skip = skip;
            Take = take;
        }

        public InventoriedItemsSpecification Specification { get; }
        public int Skip { get; }
        public int Take { get; }
    }

    public class InventoriedItemsCountPerCompanyQueryHandler : IRequestHandler<InventoriedItemsCountPerCompanyQuery, IPageableCollection<InventoriedItemsCountPerCompanyQueryResponse>>
    {
        private readonly IApplicationDbContext _context;

        public InventoriedItemsCountPerCompanyQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IPageableCollection<InventoriedItemsCountPerCompanyQueryResponse>> Handle(InventoriedItemsCountPerCompanyQuery query, CancellationToken cancellationToken)
        {
            var inventoriedItems = await _context.InventoryItems
                .Where(query.Specification.Predicate)
                .GroupBy(i => new { i.CompanyPrefix, i.Product.CompanyName }, (key, g) => new InventoriedItemsCountPerCompanyQueryResponse
                {
                    CompanyPrefix = key.CompanyPrefix,
                    CompanyName = key.CompanyName,
                    InventoriedItemsCount = g.LongCount()
                })
                .Skip(query.Skip)
                .Take(query.Take)
                .ToListAsync(cancellationToken);

            var total = await _context.InventoryItems
                .Where(query.Specification.Predicate)
                .GroupBy(i => new { i.CompanyPrefix, i.Product.CompanyName }, (key, g) => new InventoriedItemsCountPerCompanyQueryResponse
                {
                    CompanyPrefix = key.CompanyPrefix,
                    CompanyName = key.CompanyName,
                    InventoriedItemsCount = g.LongCount()
                })
                .LongCountAsync(cancellationToken);


            return new PageableCollection<InventoriedItemsCountPerCompanyQueryResponse>(inventoriedItems, total);
        }
    }
}
