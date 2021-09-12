using FluentValidation;
using MediatR;
using Products.Application.Common.Interfaces;
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
                    .WithMessage($"Tag must be in valid SGTIN-96 format which means hexadecimal characters only and strings with length {StringExtensions.TheLengthOfSgtin96String}");
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
            foreach (var tag in command.Tags)
            {
                var sgtin96Data = Sgtin96Decoder.DecodeFromSgtin96HexString(tag);
            }
            return await Task.FromResult(command.InventoryId);
        }
    }
}
