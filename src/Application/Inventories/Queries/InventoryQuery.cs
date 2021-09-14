using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Application.Common.Exceptions;
using Products.Application.Common.Interfaces;
using Products.Application.Common.Mappings;
using Products.Application.Inventories.Models;
using Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Products.Application.Inventories.Queries
{
    public class InventoryQueryResponse : IMapFrom<Inventory>
    {
        public InventoryQueryResponse()
        {
            InventoriedItems = new List<InventoriedItemModel>();
        }

        public string InventoryId { get; set; }
        public string InventoryLocation { get; set; }
        public DateTime InventoryDate { get; set; }
        public IEnumerable<InventoriedItemModel> InventoriedItems { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Inventory, InventoryQueryResponse>()
                .ForMember(d => d.InventoriedItems, o => o.MapFrom(s => s.InventoryItems));
        }
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
        private readonly IMapper _mapper;

        public InventoryQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InventoryQueryResponse> Handle(InventoryQuery query, CancellationToken cancellationToken)
        {
            var inventory = await _context.Inventories
                .Where(t => t.InventoryId == query.Id)
                .ProjectTo<InventoryQueryResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            if (inventory == null)
            {
                throw new NotFoundException($"Inventory with Id '{query.Id}' not found");
            }

            return inventory;
        }
    }
}
