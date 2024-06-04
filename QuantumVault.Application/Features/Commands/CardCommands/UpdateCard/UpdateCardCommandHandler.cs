using AutoMapper;
using MediatR;
using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Application.Exceptions;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.CardCommands.UpdateCard
{
    public class UpdateCardCommandHandler : IRequestHandler<UpdateCardCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICard _card;

        public UpdateCardCommandHandler(IMapper mapper, ICard card)
        {
            _mapper = mapper;
            _card = card;
        }

        public async Task<Unit> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new UpdateCardCommandValidator(_card);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Error submitting Card for update", validationResult);
            }

            //Convert incoming entity to domain entity
            var cardToUpdate = _mapper.Map<Card>(request);
            //Add to database 
            await _card.UpdateAsync(cardToUpdate);

            //Return result.
            return Unit.Value;
        }
    }
}
