using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.AccountTypeCommands.UpdateAccountType
{
    public class UpdateAccountTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public int AccountNumber { get; set; }
        public string TypeName { get; set; } = string.Empty;
    }
}
