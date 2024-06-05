using FluentValidation;
using QuantumVault.Application.Contracts.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.CardTypeCommands.UpdateCardType
{
    public class UpdateCardTypeCommandValidator : AbstractValidator<UpdateCardTypeCommand>
    {
        private readonly ICardTypeRepository _cardType;

        public UpdateCardTypeCommandValidator(ICardTypeRepository cardType)
        {
            _cardType = cardType;

            RuleFor(p => p.Id)
               .NotNull()
               .MustAsync(FormIdMustExist)
               .WithMessage("The specified condition was not met for {PropertyName} with value {PropertyValue}.");

            RuleFor(p => p.CardTypeName)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull();
        }

        private async Task<bool> FormIdMustExist(Guid guidId, CancellationToken token)
        {
            var checkIfCardTypeIdExist = await _cardType.GetByIdAsync(guidId);
            return checkIfCardTypeIdExist != null;
        }
    }
}
