using FluentValidation;
using QuantumVault.Application.Contracts.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.BranchCommands.UpdateBranch
{
    public class UpdateBranchCommandValidator : AbstractValidator<UpdateBranchCommand>
    {
        private readonly IBranch _branch;

        public UpdateBranchCommandValidator(IBranch branch)
        {
            _branch = branch;

            RuleFor(p => p.Id)
               .NotNull()
               .MustAsync(FormIdMustExist)
               .WithMessage("The specified condition was not met for {PropertyName} with value {PropertyValue}.");

            RuleFor(p => p.BranchName)
               .NotEmpty()
               .WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.Address)
               .NotEmpty()
               .WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.PhoneNumber)
               .NotEmpty()
               .WithMessage("{PropertyName} is required.")
               .NotNull();
        }

        private async Task<bool> FormIdMustExist(Guid guidId, CancellationToken token)
        {
            var checkIfBranchIdExist = await _branch.GetByIdAsync(guidId);
            return checkIfBranchIdExist != null;
        }
    }
}
