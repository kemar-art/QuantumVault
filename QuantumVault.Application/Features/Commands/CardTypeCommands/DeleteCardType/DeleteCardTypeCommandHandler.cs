using MediatR;
using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.CardTypeCommands.DeleteCardType
{
    public class DeleteCardTypeCommandHandler : IRequestHandler<DeleteCardTypeCommand, Unit>
    {
        private readonly ICardType _cardType;

        public DeleteCardTypeCommandHandler(ICardType cardType)
        {
            _cardType = cardType;
        }

        public async Task<Unit> Handle(DeleteCardTypeCommand request, CancellationToken cancellationToken)
        {
            //Find the card type to be deleted
            var cardTypeToDelete = await _cardType.GetByIdAsync(request.Id);

            //Verify if the record exist
            if (cardTypeToDelete is null)
            {
                throw new NotFoundException(nameof(DeleteCardTypeCommand), request.Id);
            }

            //remove the record from the database 
            await _cardType.DeleteAsync(cardTypeToDelete);

            //Return result.+
            return Unit.Value;
        }
    }
}
