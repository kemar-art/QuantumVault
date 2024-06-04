using AutoMapper;
using MediatR;
using QuantumVault.Application.Contracts.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.CardsQuery.GetAllCards
{
    public class AllCardsQueryHandler : IRequestHandler<AllCardsQuery, IEnumerable<AllCardsDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICard _card;

        public AllCardsQueryHandler(IMapper mapper, ICard card)
        {
            _mapper = mapper;
            _card = card;
        }


        public async Task<IEnumerable<AllCardsDTO>> Handle(AllCardsQuery request, CancellationToken cancellationToken)
        {
            var getAllCards = await _card.GetAllAsync();

            var mapData = _mapper.Map<IEnumerable<AllCardsDTO>>(getAllCards);

            return mapData;
        }
    }
}
