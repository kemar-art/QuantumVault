using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.CardTypeCommands.CreateCardType
{
    public class CreateCardTypeCommandValidator : AbstractValidator<CreateCardTypeCommand>
    {
        public CreateCardTypeCommandValidator()
        {
            RuleFor(p => p.CardTypeName)
                .NotEmpty()
                .WithMessage("{PropertyName} iks required")
                .NotNull();
        }
    }
}
