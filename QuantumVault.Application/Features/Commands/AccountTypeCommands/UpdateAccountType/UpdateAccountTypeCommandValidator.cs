using FluentValidation;
using QuantumVault.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.AccountTypeCommands.UpdateAccountType
{
    public class UpdateAccountTypeCommandValidator : AbstractValidator<UpdateAccountTypeCommand>
    {
        private readonly IAccountType _accountType;

        public UpdateAccountTypeCommandValidator(IAccountType accountType)
        {
            _accountType = accountType;

            RuleFor(p => p.Id)
               .NotNull()
               .MustAsync(FormIdMustExist)
               .WithMessage("The specified condition was not met for {PropertyName} with value {PropertyValue}.");

            RuleFor(p => p.TypeName)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyName} is required.");
        }

        private async Task<bool> FormIdMustExist(Guid guidId, CancellationToken token)
        {
            var checkIfAccountTypeIdExist = await _accountType.GetByIdAsync(guidId);
            return checkIfAccountTypeIdExist != null;
        }
    }
}
