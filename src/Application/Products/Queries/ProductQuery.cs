using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Application.Common.Exceptions;
using Products.Application.Common.Interfaces;
using Products.Application.Common.Mappings;
using Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Products.Application.Products.Queries
{
    public class ProductQueryResponse : IMapFrom<Product>
    {
        public string CompanyPrefix { get; set; }
        public string CompanyName { get; set; }
        public string ItemReference { get; set; }
        public string ProductName { get; set; }
    }

    public class ProductQuery : IRequest<ProductQueryResponse>
    {
        public ProductQuery(string companyPrefix, string itemReference)
        {
            CompanyPrefix = companyPrefix;
            ItemReference = itemReference;
        }

        public string CompanyPrefix { get; }
        public string ItemReference { get; }
    }

    public class ProductQueryHandler : IRequestHandler<ProductQuery, ProductQueryResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductQueryResponse> Handle(ProductQuery query, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .Where(t => t.CompanyPrefix == query.CompanyPrefix && t.ItemReference == query.ItemReference)
                .ProjectTo<ProductQueryResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            if (product == null)
            {
                throw new NotFoundException($"Product with Company Prefix '{query.CompanyPrefix}' and Item Reference '{query.ItemReference}' not found");
            }

            return product;
        }
    }
}
