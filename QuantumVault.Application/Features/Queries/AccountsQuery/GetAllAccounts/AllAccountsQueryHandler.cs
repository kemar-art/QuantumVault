using AutoMapper;
using MediatR;
using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Application.Features.Queries.AccountTypeQuery.GetAllAccountsType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.AccountsQuery.GetAllAccounts
{
    public class AllAccountsQueryHandler : IRequestHandler<AllAccountsQuery, IEnumerable<AllAccountDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IAccount _account;

        public AllAccountsQueryHandler(IMapper mapper, IAccount account)
        {
            _mapper = mapper;
            _account = account;
        }

        public async Task<IEnumerable<AllAccountDTO>> Handle(AllAccountsQuery request, CancellationToken cancellationToken)
        {
            var getAllAccount = await _account.GetAllAsync();

            var mapData = _mapper.Map<IEnumerable<AllAccountDTO>>(getAllAccount);

            return mapData;
        }
    }
}
