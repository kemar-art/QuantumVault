using AutoMapper;
using MediatR;
using QuantumVault.Application.Contracts.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.LoanQuery.GetAllLoans
{
    public class AllLoanQueryHandler : IRequestHandler<AllLoanQuery, IEnumerable<AllLoanDTO>>
    {
        private readonly ILoanRepository _loan;
        private readonly IMapper _mapper;

        public AllLoanQueryHandler(IMapper mapper, ILoanRepository loan)
        {
            _loan = loan;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AllLoanDTO>> Handle(AllLoanQuery request, CancellationToken cancellationToken)
        {
            var getAllLoans = await _loan.GetAllAsync();

            var mapData = _mapper.Map<IEnumerable<AllLoanDTO>>(getAllLoans);

            return mapData;
        }
    }
}
