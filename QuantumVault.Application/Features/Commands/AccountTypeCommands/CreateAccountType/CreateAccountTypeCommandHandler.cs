using AutoMapper;
using FluentValidation;
using MediatR;
using QuantumVault.Application.Contracts;
using QuantumVault.Application.Exceptions;
using QuantumVault.Application.Features.Commands.AccountTypeCommands.CreateAccountType;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.AccountTypeCommands.CreateAccountType
{
    public class CreateAccountTypeCommandHandler : IRequestHandler<CreateAccountTypeCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IAccountTypeRepository _accountType;

        public CreateAccountTypeCommandHandler(IMapper mapper, IAccountTypeRepository accountType)
        {
            _mapper = mapper;
            _accountType = accountType;
        }
        public async Task<Guid> Handle(CreateAccountTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new CreateAccountTypeCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any()) 
            {
                throw new BadRequestException("An error was encountered while creating Account Type", validationResult);
            }

            //Convert incoming entity to domain entity
            var accountTypeToCreate = _mapper.Map<AccountType>(request);

            //Add to database
            await _accountType.CreateAsync(accountTypeToCreate);

            //Return result.
            return accountTypeToCreate.Id;
        }
    }
}
