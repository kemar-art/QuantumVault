using AutoMapper;
using MediatR;
using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Application.Exceptions;
using QuantumVault.Application.Features.Commands.AccountCommands.CreateAccount;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.BranchCommands.CreateBranch
{
    public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IBranch _branch;

        public CreateBranchCommandHandler(IMapper mapper, IBranch branch)
        {
            _mapper = mapper;
            _branch = branch;
        }


        public async Task<Guid> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new CreateBranchCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("An error was encountered while creating Branch", validationResult);
            }

            //Convert incoming entity to domain entity
            var branchToCreate = _mapper.Map<Branch>(request);

            //Add to database
            await _branch.CreateAsync(branchToCreate);

            //Return result.
            return branchToCreate.Id;
        }
    }
}
