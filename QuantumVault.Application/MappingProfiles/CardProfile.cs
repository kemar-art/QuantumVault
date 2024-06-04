using AutoMapper;
using QuantumVault.Application.Features.Commands.CardCommands.CreateCard;
using QuantumVault.Application.Features.Commands.CardCommands.UpdateCard;
using QuantumVault.Application.Features.Queries.CardsQuery.GetAllCards;
using QuantumVault.Application.Features.Queries.CardsQuery.GetCard;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.MappingProfiles
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<Card, CardDTO>().ReverseMap();
            CreateMap<Card, AllCardsDTO>().ReverseMap();
            CreateMap<Card, CreateCardCommand>().ReverseMap();
            CreateMap<Card, UpdateCardCommand>().ReverseMap();
        }
    }
}
