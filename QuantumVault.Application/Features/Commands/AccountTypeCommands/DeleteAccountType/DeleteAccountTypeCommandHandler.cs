using MediatR;
using QuantumVault.Application.Contracts;
using QuantumVault.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.AccountTypeCommands.DeleteAccountType
{
    public class DeleteAccountTypeCommandHandler : IRequestHandler<DeleteAccountTypeCommand, Unit>
    {
        private readonly IAccountTypeRepository _accountType;

        public DeleteAccountTypeCommandHandler(IAccountTypeRepository accountType)
        {
            _accountType = accountType;
        }
        
        async Task<Unit> IRequestHandler<DeleteAccountTypeCommand, Unit>.Handle(DeleteAccountTypeCommand request, CancellationToken cancellationToken)
        {
            //Find the form to be deleted
            var accountTypeToDelete = await _accountType.GetByIdAsync(request.Id);

            //Verify if the record exist
            if (accountTypeToDelete is null)
            {
                throw new NotFoundException(nameof(DeleteAccountTypeCommand), request.Id);
            }

            //remove the record from the database
            await _accountType.DeleteAsync(accountTypeToDelete);

            //Return result.+
            return Unit.Value;
        }
    }
}
