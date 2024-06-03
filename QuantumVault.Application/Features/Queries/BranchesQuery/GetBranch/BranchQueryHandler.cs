using AutoMapper;
using MediatR;
using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Application.Exceptions;
using QuantumVault.Application.Features.Queries.AccountTypeQuery.GetAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.BranchesQuery.GetBranch
{
    public class BranchQueryHandler : IRequestHandler<BranchQuery, BranchDTO>
    {
        private readonly IMapper _mapper;
        private readonly IBranch _branch;

        public BranchQueryHandler(IMapper mapper, IBranch branch)
        {
            _mapper = mapper;
            _branch = branch;
        }

        public async Task<BranchDTO> Handle(BranchQuery request, CancellationToken cancellationToken)
        {
            //Querying the database
            var getBranch = await _branch.GetByIdAsync(request.Id);

            //Verify if the record exist
            if (getBranch is null)
            {
                throw new NotFoundException(nameof(getBranch), request.Id);
            }

            //Mapping the object from the Database to the Dto
            var mapData = _mapper.Map<BranchDTO>(getBranch);

            return mapData;
        }
    }
}
