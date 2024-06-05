using AutoMapper;
using MediatR;
using QuantumVault.Application.Contracts;
using QuantumVault.Application.Exceptions;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.AccountTypeCommands.UpdateAccountType
{
    public class UpdateAccountTypeCommandHandler : IRequestHandler<UpdateAccountTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IAccountTypeRepository _accountType;

        public UpdateAccountTypeCommandHandler(IMapper mapper, IAccountTypeRepository accountType)
        {
            _mapper = mapper;
            _accountType = accountType;
        }

        public async Task<Unit> Handle(UpdateAccountTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new UpdateAccountTypeCommandValidator(_accountType);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Error updating Account Type", validationResult);
            }

            //Convert incoming entity to domain entity
            var accountTypeToUpdate = _mapper.Map<AccountType>(request);

            //Add to database
            await _accountType.UpdateAsync(accountTypeToUpdate);

            //Return result.
            return Unit.Value;
        }
    }
}
