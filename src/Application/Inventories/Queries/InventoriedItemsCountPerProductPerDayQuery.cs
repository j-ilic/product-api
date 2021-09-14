using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Application.Common.Exceptions;
using Products.Application.Common.Interfaces;
using Products.Application.Inventories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Products.Application.Inventories.Queries
{
    public class InventoriedItemsCountPerProductPerDayQueryResponse
    {
        public string CompanyPrefix { get; set; }
        public string ItemReference { get; set; }
        public DateTime InventoryDate { get; set; }
        public long InventoriedItemsCount { get; set; }
    }

    public class InventoriedItemsCountPerProductPerDayQuery : IRequest<IPageableCollection<InventoriedItemsCountPerProductPerDayQueryResponse>>
    {
        public InventoriedItemsCountPerProductPerDayQuery(string companyPrefix, string itemReference, int skip = 0, int take = 25)
        {
            CompanyPrefix = companyPrefix;
            ItemReference = itemReference;
            Skip = skip;
            Take = take;
        }

        public string CompanyPrefix { get; }
        public string ItemReference { get; }
        public int Skip { get; }
        public int Take { get; }
    }

    public class InventoriedItemsCountPerProductPerDayQueryHandler : IRequestHandler<InventoriedItemsCountPerProductPerDayQuery, IPageableCollection<InventoriedItemsCountPerProductPerDayQueryResponse>>
    {
        private readonly IApplicationDbContext _context;

        public InventoriedItemsCountPerProductPerDayQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IPageableCollection<InventoriedItemsCountPerProductPerDayQueryResponse>> Handle(InventoriedItemsCountPerProductPerDayQuery query, CancellationToken cancellationToken)
        {
            var total = await _context.InventoryItems
                .Where(t => t.CompanyPrefix == query.CompanyPrefix && t.ItemReference == query.ItemReference)
                .GroupBy(i => new { i.CompanyPrefix, i.ItemReference, i.Inventory.InventoryDate }, (key, g) => new InventoriedItemsCountPerProductPerDayQueryResponse
                {
                    CompanyPrefix = key.CompanyPrefix,
                    ItemReference = key.ItemReference,
                    InventoryDate = key.InventoryDate,
                    InventoriedItemsCount = g.LongCount()
                })
                .LongCountAsync();

            if (total == 0)
            {
                throw new NotFoundException($"There are no inventoried items for product with Company Prefix '{query.CompanyPrefix}' and Item Reference '{query.ItemReference}'");
            }

            var inventoriedItems = await _context.InventoryItems
                .Where(t => t.CompanyPrefix == query.CompanyPrefix && t.ItemReference == query.ItemReference)
                .GroupBy(i => new { i.CompanyPrefix, i.ItemReference, i.Inventory.InventoryDate }, (key, g) => new InventoriedItemsCountPerProductPerDayQueryResponse
                {
                    CompanyPrefix = key.CompanyPrefix,
                    ItemReference = key.ItemReference,
                    InventoryDate = key.InventoryDate,
                    InventoriedItemsCount = g.LongCount()
                })
                .OrderByDescending(t => t.InventoryDate)
                .Skip(query.Skip)
                .Take(query.Take)
                .ToListAsync(cancellationToken);

            var res = new PageableCollection<InventoriedItemsCountPerProductPerDayQueryResponse>(inventoriedItems, total);

            return res;
        }
    }
}
