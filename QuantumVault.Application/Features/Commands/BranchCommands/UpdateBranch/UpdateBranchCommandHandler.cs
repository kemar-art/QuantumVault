using AutoMapper;
using MediatR;
using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Application.Exceptions;
using QuantumVault.Application.Features.Commands.AccountCommands.UpdateAccount;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.BranchCommands.UpdateBranch
{
    public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IBranch _branch;

        public UpdateBranchCommandHandler(IMapper mapper, IBranch branch)
        {
            _mapper = mapper;
            _branch = branch;
        }

        public async Task<Unit> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new UpdateBranchCommandValidator(_branch);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Error updating Branch", validationResult);
            }

            //Convert incoming entity to domain entity
            var branchToUpdate = _mapper.Map<Branch>(request);

            //Add to database
            await _branch.UpdateAsync(branchToUpdate);

            //Return result.
            return Unit.Value;
        }
    }
}
