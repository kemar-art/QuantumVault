using MediatR;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.BranchCommands.UpdateBranch
{
    public class UpdateBranchCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string BranchName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public ICollection<Account>? Accounts { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<AuditLog>? AuditLogs { get; set; }
    }
}
