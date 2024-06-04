using AutoMapper;
using MediatR;
using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.CardsQuery.GetCard
{
    public class CardQueryHandler : IRequestHandler<CardQuery, CardDTO>
    {
        private readonly IMapper _mapper;
        private readonly ICard _card;

        public CardQueryHandler(IMapper mapper, ICard card)
        {
            _mapper = mapper;
            _card = card;
        }

        public async Task<CardDTO> Handle(CardQuery request, CancellationToken cancellationToken)
        {
            //Querying the database
            var getCard = await _card.GetByIdAsync(request.Id);

            //Verify if the record exist
            if (getCard is null) 
            {
                throw new NotFoundException(nameof(CardQuery), request.Id);
            }

            //Mapping the object from the Database to the Dto
            var mapData = _mapper.Map<CardDTO>(getCard);

            return mapData;
        }
    }
}
