using AutoMapper;
using QuantumVault.Application.Features.Queries.LoanQuery.GetAllLoans;
using QuantumVault.Application.Features.Queries.LoanQuery.GetLoan;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.MappingProfiles
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<Loan, LoadDTO>().ReverseMap();
            CreateMap<Loan, AllLoanDTO>().ReverseMap();
        }
    }
}
