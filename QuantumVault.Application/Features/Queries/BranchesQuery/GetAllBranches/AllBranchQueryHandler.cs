using AutoMapper;
using MediatR;
using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Application.Features.Queries.AccountTypeQuery.GetAllAccountsType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.BranchesQuery.GetAllBranch
{
    public class AllBranchQueryHandler : IRequestHandler<AllBranchQuery, IEnumerable<AllBranchDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IBranchRepository _branch;

        public AllBranchQueryHandler(IMapper mapper, IBranchRepository branch)
        {
            _mapper = mapper;
            _branch = branch;
        }

        public async Task<IEnumerable<AllBranchDTO>> Handle(AllBranchQuery request, CancellationToken cancellationToken)
        {
            var getAllBranches = await _branch.GetAllAsync();

            var mapData = _mapper.Map<IEnumerable<AllBranchDTO>>(getAllBranches);

            return mapData;
        }
    }
}
