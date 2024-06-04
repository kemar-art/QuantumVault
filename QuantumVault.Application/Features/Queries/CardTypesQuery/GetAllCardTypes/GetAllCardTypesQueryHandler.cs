using AutoMapper;
using MediatR;
using QuantumVault.Application.Contracts.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.CardTypesQuery.GetAllCardTypes
{
    public class GetAllCardTypesQueryHandler : IRequestHandler<GetAllCardTypesQuery, IEnumerable<AllCardTypesDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICardType _cardType;

        public GetAllCardTypesQueryHandler(IMapper mapper, ICardType cardType)
        {
            _mapper = mapper;
            _cardType = cardType;
        }

        public async Task<IEnumerable<AllCardTypesDTO>> Handle(GetAllCardTypesQuery request, CancellationToken cancellationToken)
        {
            var getAllForms = await _cardType.GetAllAsync();

            var mapData = _mapper.Map<IEnumerable<AllCardTypesDTO>>(getAllForms);

            return mapData;
        }
    }
}

