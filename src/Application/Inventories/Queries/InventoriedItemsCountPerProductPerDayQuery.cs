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
        public InventoriedItemsCountPerProductPerDayQueryResponse()
        {
            ItemsCountPerDay = new List<CountPerDay>();
        }

        public string CompanyPrefix { get; set; }
        public string ItemReference { get; set; }
        public IEnumerable<CountPerDay> ItemsCountPerDay { get; set; }
    }

    public class InventoriedItemsCountPerProductPerDayQuery : IRequest<InventoriedItemsCountPerProductPerDayQueryResponse>
    {
        public InventoriedItemsCountPerProductPerDayQuery(string companyPrefix, string itemReference)
        {
            CompanyPrefix = companyPrefix;
            ItemReference = itemReference;
        }

        public string CompanyPrefix { get; }
        public string ItemReference { get; }
    }

    public class InventoriedItemsCountPerProductPerDayQueryHandler : IRequestHandler<InventoriedItemsCountPerProductPerDayQuery, InventoriedItemsCountPerProductPerDayQueryResponse>
    {
        private readonly IApplicationDbContext _context;

        public InventoriedItemsCountPerProductPerDayQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<InventoriedItemsCountPerProductPerDayQueryResponse> Handle(InventoriedItemsCountPerProductPerDayQuery query, CancellationToken cancellationToken)
        {
            var inventoriedItems = await _context.InventoryItems
                .Where(t => t.CompanyPrefix == query.CompanyPrefix && t.ItemReference == query.ItemReference)
                .Select(t => new
                {
                    t.CompanyPrefix,
                    t.ItemReference,
                    t.Inventory.InventoryDate
                })
                .ToListAsync(cancellationToken);

            if (inventoriedItems.Count == 0)
            {
                throw new NotFoundException($"There are no inventoried items for product with Company Prefix '{query.CompanyPrefix}' and Item Reference '{query.ItemReference}'");
            }

            var res = new InventoriedItemsCountPerProductPerDayQueryResponse
            {
                CompanyPrefix = query.CompanyPrefix,
                ItemReference = query.ItemReference,
                ItemsCountPerDay = inventoriedItems.GroupBy(
                        i => new { i.CompanyPrefix, i.ItemReference, i.InventoryDate }, (key, g) => new CountPerDay
                        {
                            Day = key.InventoryDate,
                            Count = g.LongCount()
                        }
                    )
            };

            return res;
        }
    }
}
