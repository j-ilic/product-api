using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Application.Common.Interfaces;
using Products.Domain.Entities;
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
        public string CompanyPrefix { get; set; }
        public string CompanyName { get; set; }
        public string ItemReference { get; set; }
        public string ProductName { get; set; }
    }

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(t => t.CompanyPrefix)
                .NotEmpty()
                //.MinimumLength(6)
                .MaximumLength(12)
                .Must(t => t.All(c => char.IsDigit(c)));
            RuleFor(t => t.CompanyName).NotEmpty();
            RuleFor(t => t.ItemReference)
                .NotEmpty()
                //.MinimumLength(1)
                .MaximumLength(7)
                .Must(t => t.All(c => char.IsDigit(c)));
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

        public async Task<long> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            bool productExists = await _context.Products.AnyAsync(t => t.CompanyPrefix == command.CompanyPrefix && t.ItemReference == command.ItemReference, cancellationToken);
            if (productExists)
            {
                throw new InvalidOperationException("Product with given parameters already exists");
            }

            Product newProduct = new Product
            {
                CompanyName = command.CompanyName,
                CompanyPrefix = command.CompanyPrefix,
                ItemReference = command.ItemReference,
                ProductName = command.ProductName
            };

            _context.Products.Add(newProduct);

            await _context.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(1);
        }
    }
}
