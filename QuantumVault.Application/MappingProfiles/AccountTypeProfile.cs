using AutoMapper;
using QuantumVault.Application.Features.Commands.AccountTypeCommands.CreateAccountType;
using QuantumVault.Application.Features.Commands.AccountTypeCommands.UpdateAccountType;
using QuantumVault.Application.Features.Queries.AccountTypeQuery.GetAccount;
using QuantumVault.Application.Features.Queries.AccountTypeQuery.GetAllAccountsType;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.MappingProfiles;

public class AccountTypeProfile : Profile
{
    public AccountTypeProfile()
    {
        CreateMap<AccountType, AccountTypeDTO>().ReverseMap();
        CreateMap<AccountType, AllAccountsTypeDTO>().ReverseMap();
        CreateMap<AccountType, CreateAccountTypeCommand>().ReverseMap();
        CreateMap<AccountType, UpdateAccountTypeCommand>().ReverseMap();
    }
}
