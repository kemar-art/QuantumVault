using AutoMapper;
using MediatR;
using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Application.Exceptions;
using QuantumVault.Application.Features.Commands.AccountTypeCommands.CreateAccountType;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.AccountCommands.CreateAccount
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _account;

        public CreateAccountCommandHandler(IMapper mapper, IAccountRepository account)
        {
            _mapper = mapper;
            _account = account;
        }

        public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new CreateAccountCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("An error was encountered while creating Account", validationResult);
            }

            //Convert incoming entity to domain entity
            var accountToCreate = _mapper.Map<Account>(request);

            //Add to database
            await _account.CreateAsync(accountToCreate);

            //Return result.
            return accountToCreate.Id;
        }
    }
}
