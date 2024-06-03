using AutoMapper;
using MediatR;
using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Application.Exceptions;
using QuantumVault.Application.Features.Commands.AccountTypeCommands.UpdateAccountType;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.AccountCommands.UpdateAccount
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IAccount _account;

        public UpdateAccountCommandHandler(IMapper mapper, IAccount account)
        {
            _mapper = mapper;
            _account = account;
        }

        public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new UpdateAccountCommandValidator(_account);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Error updating Account", validationResult);
            }

            //Convert incoming entity to domain entity
            var accountToUpdate = _mapper.Map<Account>(request);

            //Add to database
            await _account.UpdateAsync(accountToUpdate);

            //Return result.
            return Unit.Value;
        }
    }
}
