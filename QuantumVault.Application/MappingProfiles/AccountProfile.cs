using AutoMapper;
using QuantumVault.Application.Features.Commands.AccountCommands.CreateAccount;
using QuantumVault.Application.Features.Commands.AccountCommands.UpdateAccount;
using QuantumVault.Application.Features.Queries.AccountsQuery.GetAccount;
using QuantumVault.Application.Features.Queries.AccountsQuery.GetAllAccounts;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.MappingProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDTO>().ReverseMap();
            CreateMap<Account, AllAccountDTO>().ReverseMap();
            CreateMap<Account, CreateAccountCommand>().ReverseMap();
            CreateMap<Account, UpdateAccountCommand>().ReverseMap();
        }
    }
}
