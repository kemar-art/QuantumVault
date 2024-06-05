using MediatR;
using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.CardCommands.DaleteCard
{
    public class DeleteCardCommandHandler : IRequestHandler<DeleteCardCommand, Unit>
    {
        private readonly ICardRepository _card;

        public DeleteCardCommandHandler(ICardRepository card)
        {
            _card = card;
        }

        public async Task<Unit> Handle(DeleteCardCommand request, CancellationToken cancellationToken)
        {
            //Find the form to be deleted
            var cardToDelete = await _card.GetByIdAsync(request.Id);

            //Verify if the record exist
            if (cardToDelete is null)
            {
                throw new NotFoundException(nameof(DeleteCardCommand), request.Id);
            }

            //remove the record from the database 
            await _card.DeleteAsync(cardToDelete);

            //Return result.+
            return Unit.Value;
        }
    }
}
