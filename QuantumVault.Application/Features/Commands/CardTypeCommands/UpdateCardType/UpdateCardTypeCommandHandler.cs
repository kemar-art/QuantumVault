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

namespace QuantumVault.Application.Features.Commands.CardTypeCommands.UpdateCardType
{
    public class UpdateCardTypeCommandHandler : IRequestHandler<UpdateCardTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICardType _cardType;

        public UpdateCardTypeCommandHandler(IMapper mapper, ICardType cardType)
        {
            _mapper = mapper;
            _cardType = cardType;
        }

        public async Task<Unit> Handle(UpdateCardTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new UpdateCardTypeCommandValidator(_cardType);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Error submitting Card Type for update", validationResult);
            }

            //Convert incoming entity to domain entity
            var cardTypeToUpdate = _mapper.Map<CardType>(request);

            //Add to database 
            await _cardType.UpdateAsync(cardTypeToUpdate);

            //Return result.
            return Unit.Value;
        }
    }
}
