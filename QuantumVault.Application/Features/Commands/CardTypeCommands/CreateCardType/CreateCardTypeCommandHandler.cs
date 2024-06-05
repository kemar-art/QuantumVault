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

namespace QuantumVault.Application.Features.Commands.CardTypeCommands.CreateCardType
{
    public class CreateCardTypeCommandHandler : IRequestHandler<CreateCardTypeCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ICardTypeRepository _cardType;

        public CreateCardTypeCommandHandler(IMapper mapper, ICardTypeRepository cardType)
        {
            _mapper = mapper;
            _cardType = cardType;
        }

        public async Task<Guid> Handle(CreateCardTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new CreateCardTypeCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Error submitting Card Type for creation", validationResult);
            }

            //Convert incoming entity to domain entity
            var cardTypeToCreate = _mapper.Map<CardType>(request);
            //Add to database 
            await _cardType.CreateAsync(cardTypeToCreate);

            //Return result.
            return cardTypeToCreate.Id;
        }
    }
}
