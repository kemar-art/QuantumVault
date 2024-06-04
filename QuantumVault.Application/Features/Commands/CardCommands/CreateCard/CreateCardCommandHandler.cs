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

namespace QuantumVault.Application.Features.Commands.CardCommands.CreateCard
{
    public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ICard _card;

        public CreateCardCommandHandler(IMapper mapper, ICard card)
        {
            _mapper = mapper;
            _card = card;
        }

        public async Task<Guid> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new CreateCardCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any()) 
            {
                throw new BadRequestException("Error submitting Card for creation", validationResult);
            }

            //Convert incoming entity to domain entity
            var cardToCreate = _mapper.Map<Card>(request);

            //Add to database 
            await _card.CreateAsync(cardToCreate);

            //Return result.
            return cardToCreate.Id;
        }
    }
}
