using FluentValidation;
using MediatR;
using Products.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Products.Application.Products.Commands
{
    public class CreateProductCommand : IRequest<long>
    {
        public long CompanyPrefix { get; set; }
        public string CompanyName { get; set; }
        public long ItemReference { get; set; }
        public string ProductName { get; set; }
    }

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(t => t.CompanyPrefix).NotEmpty();
            RuleFor(t => t.CompanyName).NotEmpty();
            RuleFor(t => t.ItemReference).NotEmpty();
            RuleFor(t => t.ProductName).NotEmpty();
        }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, long>
    {
        private readonly IApplicationDbContext _context;

        public CreateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(1);
        }
    }
}
