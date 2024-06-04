using AutoMapper;
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
        }
    }
}
