using MediatR;
using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Application.Exceptions;
using QuantumVault.Application.Features.Commands.AccountCommands.DeleteAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.BranchCommands.DeleteBranch
{
    public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand, Unit>
    {
        private readonly IBranch _branch;

        public DeleteBranchCommandHandler(IBranch branch)
        {
            _branch = branch;
        }

        public async Task<Unit> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            //Find the form to be deleted
            var branchToDelete = await _branch.GetByIdAsync(request.Id);

            //Verify if the record exist
            if (branchToDelete is null)
            {
                throw new NotFoundException(nameof(DeleteBranchCommand), request.Id);
            }

            //remove the record from the database
            await _branch.DeleteAsync(branchToDelete);

            //Return result.+
            return Unit.Value;
        }
    }
}
