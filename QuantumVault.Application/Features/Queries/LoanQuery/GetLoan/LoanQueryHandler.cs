using AutoMapper;
using MediatR;
using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.LoanQuery.GetLoan
{
    public class LoanQueryHandler : IRequestHandler<LoanQuery, LoadDTO>
    {
        private readonly IMapper _mapper;
        private readonly ILoan _loan;

        public LoanQueryHandler(IMapper mapper, ILoan loan)
        {
            _mapper = mapper;
            _loan = loan;
        }

        public async Task<LoadDTO> Handle(LoanQuery request, CancellationToken cancellationToken)
        {
            //Querying the database
            var getLoan = await _loan.GetByIdAsync(request.Id);

            //Verify if the record exist
            if (getLoan is null)
            {
                throw new NotFoundException(nameof(LoanQuery), request.Id);
            }

            //Mapping the object from the Database to the Dto
            var mapData = _mapper.Map<LoadDTO>(getLoan);

            return mapData;
        }
    }
}
