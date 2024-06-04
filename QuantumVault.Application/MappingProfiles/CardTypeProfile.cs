using AutoMapper;
using QuantumVault.Application.Features.Commands.CardTypeCommands.CreateCardType;
using QuantumVault.Application.Features.Commands.CardTypeCommands.UpdateCardType;
using QuantumVault.Application.Features.Queries.CardTypesQuery.GetAllCardTypes;
using QuantumVault.Application.Features.Queries.CardTypesQuery.GetCardType;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.MappingProfiles
{
    public class CardTypeProfile : Profile
    {
        public CardTypeProfile()
        {
            CreateMap<CardType, CardTypeDTO>().ReverseMap();
            CreateMap<CardType, AllCardTypesDTO>().ReverseMap();
            CreateMap<CardType, CreateCardTypeCommand>().ReverseMap();
            CreateMap<CardType, UpdateCardTypeCommand>().ReverseMap();
        }
    }
}
