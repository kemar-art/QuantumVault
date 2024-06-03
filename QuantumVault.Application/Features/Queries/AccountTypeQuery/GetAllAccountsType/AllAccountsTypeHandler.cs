using AutoMapper;
using MediatR;
using QuantumVault.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.AccountTypeQuery.GetAllAccountsType
{
    public class AllAccountsTypeHandler : IRequestHandler<AllAccountsTypeQuery, IEnumerable<AllAccountsTypeDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IAccountType _accountType;

        public AllAccountsTypeHandler(IMapper mapper, IAccountType accountType)
        {
            _mapper = mapper;
            _accountType = accountType;
        }
        public async Task<IEnumerable<AllAccountsTypeDTO>> Handle(AllAccountsTypeQuery request, CancellationToken cancellationToken)
        {
            var getAllAccountType = await _accountType.GetAllAsync();

            var mapData = _mapper.Map<IEnumerable<AllAccountsTypeDTO>>(getAllAccountType);

            return mapData;
        }
    }
}
