using AutoMapper;
using QuantumVault.Application.Features.Commands.CustomerCommands.CreateCommand;
using QuantumVault.Application.Features.Commands.CustomerCommands.UpdateCommand;
using QuantumVault.Application.Features.Queries.AccountsQuery.GetAccount;
using QuantumVault.Application.Features.Queries.CustomerQuery.GetAllCustomers;
using QuantumVault.Application.Features.Queries.CustomerQuery.GetCustomer;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.MappingProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap()
           .ForMember(dest => dest.Accounts, opt => opt.MapFrom(src => src.Accounts));


            CreateMap<Customer, AllCustomersDTO>().ReverseMap();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();


            CreateMap<Account, CustomerAccountDTO>()
            .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.BranchName));
        }
    }
}
