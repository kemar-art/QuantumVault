﻿using AutoMapper;
using MediatR;
using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.CardTypesQuery.GetCardType
{
    public class GetCardTypeQueryHandler : IRequestHandler<GetCardTypeQuery, CardTypeDTO>
    {
        private readonly IMapper _mapper;
        private readonly ICardType _cardType;

        public GetCardTypeQueryHandler(IMapper mappper, ICardType cardType)
        {
            _mapper = mappper;
            _cardType = cardType;
        }

        public async Task<CardTypeDTO> Handle(GetCardTypeQuery request, CancellationToken cancellationToken)
        {
            //Querying the database
            var getCardType = await _cardType.GetByIdAsync(request.Id);

            //Verify if the record exist
            if (getCardType is null)
            {
                throw new NotFoundException(nameof(GetCardTypeQuery), request.Id);
            }

            //Mapping the object from the Database to the Dto
            var mapData = _mapper.Map<CardTypeDTO>(getCardType);

            return mapData;
        }
    }
}
