using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.AccountTypeCommands.CreateAccountType
{
    public class CreateAccountTypeCommand : IRequest<Guid>
    {
        public string TypeName { get; set; } = string.Empty; 
    }
}
