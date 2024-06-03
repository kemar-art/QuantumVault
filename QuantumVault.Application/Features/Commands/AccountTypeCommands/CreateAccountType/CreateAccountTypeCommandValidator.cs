using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.AccountTypeCommands.CreateAccountType
{
    public class CreateAccountTypeCommandValidator : AbstractValidator<CreateAccountTypeCommand>
    {
        public CreateAccountTypeCommandValidator() 
        {
            RuleFor(p => p.TypeName)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required.");
        }
    }
}
