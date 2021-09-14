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
    public class InventoriedItemsCountPerProductPerInventoryQueryResponse
    {
        public string CompanyPrefix { get; set; }
        public string ItemReference { get; set; }
        public string InventoryId { get; set; }
        public long InventoriedItemsCount { get; set; }
    }

    public class InventoriedItemsCountPerProductPerInventoryQuery : IRequest<IPageableCollection<InventoriedItemsCountPerProductPerInventoryQueryResponse>>
    {
        public InventoriedItemsCountPerProductPerInventoryQuery(InventoriedItemsSpecification specification, int skip = 0, int take = 25)
        {
            Specification = specification;
            Skip = skip;
            Take = take;
        }

        public InventoriedItemsSpecification Specification { get; }
        public int Skip { get; }
        public int Take { get; }
    }

    public class InventoriedItemsCountPerProductPerInventoryQueryHandler : IRequestHandler<InventoriedItemsCountPerProductPerInventoryQuery, IPageableCollection<InventoriedItemsCountPerProductPerInventoryQueryResponse>>
    {
        private readonly IApplicationDbContext _context;

        public InventoriedItemsCountPerProductPerInventoryQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IPageableCollection<InventoriedItemsCountPerProductPerInventoryQueryResponse>> Handle(InventoriedItemsCountPerProductPerInventoryQuery query, CancellationToken cancellationToken)
        {
            var inventoriedItems = await _context.InventoryItems
                .Where(query.Specification.Predicate)
                .GroupBy(i => new { i.CompanyPrefix, i.ItemReference, i.InventoryId }, (key, g) => new InventoriedItemsCountPerProductPerInventoryQueryResponse
                {
                    CompanyPrefix = key.CompanyPrefix,
                    ItemReference = key.ItemReference,
                    InventoryId = key.InventoryId,
                    InventoriedItemsCount = g.LongCount()
                })
                .Skip(query.Skip)
                .Take(query.Take)
                .ToListAsync(cancellationToken);

            var total = await _context.InventoryItems
                .Where(query.Specification.Predicate)
                .GroupBy(i => new { i.CompanyPrefix, i.ItemReference, i.InventoryId }, (key, g) => new InventoriedItemsCountPerProductPerInventoryQueryResponse
                {
                    CompanyPrefix = key.CompanyPrefix,
                    ItemReference = key.ItemReference,
                    InventoryId = key.InventoryId,
                    InventoriedItemsCount = g.LongCount()
                })
                .LongCountAsync(cancellationToken);

            return new PageableCollection<InventoriedItemsCountPerProductPerInventoryQueryResponse>(inventoriedItems, total);
        }
    }
}
