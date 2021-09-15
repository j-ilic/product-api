using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Application.Common.Exceptions;
using Products.Application.Common.Interfaces;
using Products.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Products.Application.Inventories.Commands
{
    public class CreateInventoryCommand : IRequest<string>
    {
        public CreateInventoryCommand()
        {
            Tags = new List<string>();
        }

        public string InventoryId { get; set; }
        public string InventoryLocation { get; set; }
        public DateTime InventoryDate { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }

    public class CreateInventoryCommandValidator : AbstractValidator<CreateInventoryCommand>
    {
        public CreateInventoryCommandValidator()
        {
            RuleFor(t => t.InventoryId)
                .NotEmpty()
                .MaximumLength(32)
                .Must(i => i.IsAlphanumeric());
            RuleFor(t => t.InventoryLocation).NotEmpty();
            RuleFor(t => t.InventoryDate).NotEmpty();
            RuleFor(t => t.Tags).NotEmpty();
            RuleForEach(t => t.Tags)
                .Must(t => t.IsValidSgtin96Format())
                    .WithMessage($"Tag must be in valid SGTIN-96 format which means hexadecimal characters only and strings with length {StringExtensions.TheLengthOfSgtin96String}")
                .Must((command, tag) => command.Tags.Count(t => t == tag) == 1)
                    .WithMessage((command, tag) => $"Duplicate tags not allowed. Found duplicate tag '{tag}'");
        }
    }

    public class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommand, string>
    {
        private readonly IApplicationDbContext _context;

        public CreateInventoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateInventoryCommand command, CancellationToken cancellationToken)
        {
            bool inventoryExists = await _context.Inventories.AnyAsync(t => t.InventoryId == command.InventoryId, cancellationToken);

            if (inventoryExists)
            {
                throw new EntityExistsException($"Inventory with Id '{command.InventoryId}' already exists");
            }

            Inventory newInventory = new Inventory
            {
                InventoryId = command.InventoryId,
                InventoryLocation = command.InventoryLocation,
                InventoryDate = command.InventoryDate.Date
            };

            foreach (var tag in command.Tags)
            {
                var sgtin96Data = Sgtin96Decoder.DecodeFromSgtin96HexString(tag);
                newInventory.InventoryItems.Add(new InventoryItem
                {
                    CompanyPrefix = sgtin96Data.CompanyPrefix,
                    Filter = sgtin96Data.Filter,
                    HexTag = tag,
                    ItemReference = sgtin96Data.ItemReference,
                    SerialNumber = sgtin96Data.SerialNumber,
                    TagUri = sgtin96Data.TagUri
                });
            }

            _context.Inventories.Add(newInventory);

            await _context.SaveChangesAsync(cancellationToken);

            return newInventory.InventoryId;
        }
    }
}
