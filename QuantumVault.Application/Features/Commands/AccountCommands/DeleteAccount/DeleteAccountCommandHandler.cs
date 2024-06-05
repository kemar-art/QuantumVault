using MediatR;
using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Application.Exceptions;
using QuantumVault.Application.Features.Commands.AccountTypeCommands.DeleteAccountType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.AccountCommands.DeleteAccount
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, Unit>
    {
        private readonly IAccountRepository _account;

        public DeleteAccountCommandHandler(IAccountRepository account)
        {
            _account = account;
        }

        public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            //Find the form to be deleted
            var accountToDelete = await _account.GetByIdAsync(request.Id);

            //Verify if the record exist
            if (accountToDelete is null)
            {
                throw new NotFoundException(nameof(DeleteAccountCommand), request.Id);
            }

            //remove the record from the database
            await _account.DeleteAsync(accountToDelete);

            //Return result.+
            return Unit.Value;
        }
    }
}
