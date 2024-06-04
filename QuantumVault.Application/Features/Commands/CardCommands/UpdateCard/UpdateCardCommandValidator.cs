using FluentValidation;
using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.CardCommands.UpdateCard
{
    public class UpdateCardCommandValidator : AbstractValidator<UpdateCardCommand>
    {
        private readonly ICard _card;

        public UpdateCardCommandValidator(ICard card)
        {
            _card = card;


            RuleFor(p => p.Id)
              .NotNull()
              .MustAsync(FormIdMustExist)
              .WithMessage("The specified condition was not met for {PropertyName} with value {PropertyValue}.");

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

        private async Task<bool> FormIdMustExist(Guid guidId, CancellationToken token)
        {
            var checkIfCardIdExist = await _card.GetByIdAsync(guidId);
            return checkIfCardIdExist != null;
        }
    }
}
