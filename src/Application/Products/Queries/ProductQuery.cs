using MediatR;
using Products.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Products.Application.Products.Queries
{
    public class ProductQueryResponse
    {
        public string CompanyPrefix { get; set; }
        public string CompanyName { get; set; }
        public string ItemReference { get; set; }
        public string ProductName { get; set; }
    }

    public class ProductQuery : IRequest<ProductQueryResponse>
    {
        public ProductQuery(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }

    public class ProductQueryHandler : IRequestHandler<ProductQuery, ProductQueryResponse>
    {
        private readonly IApplicationDbContext _context;

        public ProductQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductQueryResponse> Handle(ProductQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new ProductQueryResponse
            {
                CompanyPrefix = "3319361",
                CompanyName = "Sanford LLC",
                ItemReference = "407205",
                ProductName = "Beans - Kidney, Red Dry"
            });
        }
    }
}
