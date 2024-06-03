using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Domain
{
    public class Branch
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string BranchName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public ICollection<Account>? Accounts { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<AuditLog>? AuditLogs { get; set; }
    }
}
