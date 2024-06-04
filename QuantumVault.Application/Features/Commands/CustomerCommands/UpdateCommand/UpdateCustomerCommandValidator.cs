using FluentValidation;
using QuantumVault.Application.Contracts.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.CustomerCommands.UpdateCommand
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        private readonly ICustomer _customer;

        public UpdateCustomerCommandValidator(ICustomer customer)
        {
            _customer = customer;

            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(FormIdMustExist)
                .WithMessage("The specified condition was not met for {PropertyName} with value {PropertyValue}.");

            RuleFor(p => p.FirstName)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.LastName)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Email)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .EmailAddress()
                .WithMessage("A valid email is required.")
                .NotNull();

            RuleFor(p => p.Address)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Email)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .EmailAddress()
                .WithMessage("A valid email is required.")
                .NotNull();

            RuleFor(p => p.DateOfBirth)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull();
        }

        private async Task<bool> FormIdMustExist(Guid guid, CancellationToken token)
        {
            var checkIfCustomerIdExist = await _customer.GetByIdAsync(guid);
            return checkIfCustomerIdExist != null;
        }
    }
}
