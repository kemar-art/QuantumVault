using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.CardCommands.CreateCard
{
    public class CreateCardCommandValidator : AbstractValidator<CreateCardCommand>
    {
        public CreateCardCommandValidator()
        {
            RuleFor(p => p.CardNumber)
              .NotEmpty()
              .WithMessage("{PropertyName} is required.")
              .NotNull();

            RuleFor(p => p.ExpiryDate)
              .NotEmpty()
              .WithMessage("{PropertyName} is required.")
              .NotNull();

            RuleFor(p => p.CustomerId)
              .NotEmpty()
              .WithMessage("{PropertyName} is required.")
              .NotNull();

            RuleFor(p => p.CardTypeId)
              .NotEmpty()
              .WithMessage("{PropertyName} is required.")
              .NotNull();
        }
    }
}
