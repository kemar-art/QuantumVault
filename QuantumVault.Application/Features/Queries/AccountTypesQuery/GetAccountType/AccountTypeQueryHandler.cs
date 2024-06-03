using AutoMapper;
using MediatR;
using QuantumVault.Application.Contracts;
using QuantumVault.Application.Exceptions;
using QuantumVault.Application.Features.Queries.AccountTypeQuery.GetAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.AccountTypeQuery.GetAccountType
{
    public class AccountTypeQueryHandler : IRequestHandler<AccountTypeQuery, AccountTypeDTO>
    {
        private readonly IMapper _mapper;
        private readonly IAccountType _accountType;

        public AccountTypeQueryHandler(IMapper mapper, IAccountType accountType)
        {
            _mapper = mapper;
            _accountType = accountType;
        }

        public async Task<AccountTypeDTO> Handle(AccountTypeQuery request, CancellationToken cancellationToken)
        {
            //Querying the database
            var getAccountType = await _accountType.GetByIdAsync(request.Id);

            //Verify if the record exist
            if (getAccountType is null) 
            { 
                throw new NotFoundException(nameof(getAccountType), request.Id);
            }

            //Mapping the object from the Database to the Dto
            var mapData = _mapper.Map<AccountTypeDTO>(getAccountType);

            return mapData;
        }
    }
}
