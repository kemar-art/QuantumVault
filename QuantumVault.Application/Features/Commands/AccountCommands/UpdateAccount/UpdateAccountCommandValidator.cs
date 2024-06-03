using FluentValidation;
using QuantumVault.Application.Contracts.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.AccountCommands.UpdateAccount
{
    public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
    {
        private readonly IAccount _account;

        public UpdateAccountCommandValidator(IAccount account)
        {
            _account = account;

            RuleFor(p => p.Id)
               .NotNull()
               .MustAsync(FormIdMustExist)
               .WithMessage("The specified condition was not met for {PropertyName} with value {PropertyValue}.");

            RuleFor(p => p.AccountNumber)
               .NotEmpty()
               .WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.Balance)
               .NotEmpty()
               .WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.CreatedDate)
               .NotEmpty()
               .WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.CustomerId)
               .NotEmpty()
               .WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.AccountTypeId)
               .NotEmpty()
               .WithMessage("{PropertyName} is required.")
               .NotNull();
        }

        private async Task<bool> FormIdMustExist(Guid guid, CancellationToken token)
        {
            var checkIfAccountIdExist = await _account.GetByIdAsync(guid);
            return checkIfAccountIdExist != null;
        }
    }
}
