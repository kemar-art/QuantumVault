using FluentValidation;
using QuantumVault.Application.Contracts.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.EmployeeCommands.UpdateEmployee
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        private readonly IEmployee _employee;

        public UpdateEmployeeCommandValidator(IEmployee employee)
        {
            _employee = employee;

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

            RuleFor(p => p.PhoneNumber)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(12)
                .WithMessage("{PropertyName} must not be less than 10 digits.")
                .MaximumLength(12)
                .WithMessage("{PropertyName} must not be exceed 10 digits.")
                .Matches(@"^\d{3}-\d{3}-\d{4}$")
                .WithMessage("{PropertyName} is not valid. Expected format: 123-456-7890.");
        }

        private async Task<bool> FormIdMustExist(Guid guidId, CancellationToken token)
        {
            var checkIfFormIdExist = await _employee.GetByIdAsync(guidId);
            return checkIfFormIdExist != null;
        }
    }
}
