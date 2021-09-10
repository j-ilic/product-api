using MediatR;
using Products.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Products.Application.Inventories.Queries
{
    public class InventoryQueryResponse
    {
        public InventoryQueryResponse()
        {
            Tags = new List<string>();
        }

        public string InventoryId { get; set; }
        public string InventoryLocation { get; set; }
        public DateTime InventoryDate { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }

    public class InventoryQuery : IRequest<InventoryQueryResponse>
    {
        public InventoryQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }

    public class InventoryQueryHandler : IRequestHandler<InventoryQuery, InventoryQueryResponse>
    {
        private readonly IApplicationDbContext _context;

        public InventoryQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<InventoryQueryResponse> Handle(InventoryQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new InventoryQueryResponse
            {
                InventoryId = "AJSK3737435849KJJS",
                InventoryLocation = "Zagreb",
                InventoryDate = DateTime.Now,
                Tags = new List<string>
                {
                    "3098D0A357783C0034E9DF74",
                    "3019B9368A10A6C022E76FF5"
                }
            });
        }
    }
}
