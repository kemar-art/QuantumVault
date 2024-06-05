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

namespace QuantumVault.Application.Features.Queries.AccountsQuery.GetAccount
{
    public class AccountQueryHandler : IRequestHandler<AccountQuery, AccountDTO>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _account;

        public AccountQueryHandler(IMapper mapper, IAccountRepository account)
        {
            _mapper = mapper;
            _account = account;
        }

        public async Task<AccountDTO> Handle(AccountQuery request, CancellationToken cancellationToken)
        {
            //Querying the database
            var getAccount = await _account.GetByIdAsync(request.Id);

            //Verify if the record exist
            if (getAccount is null)
            {
                throw new NotFoundException(nameof(getAccount), request.Id);
            }

            //Mapping the object from the Database to the Dto
            var mapData = _mapper.Map<AccountDTO>(getAccount);

            return mapData;
        }
    }
}
