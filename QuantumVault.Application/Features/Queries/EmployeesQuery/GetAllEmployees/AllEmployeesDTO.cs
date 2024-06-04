using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.EmployeesQuery.GetAllEmployees
{
    public class AllEmployeesDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        //public Branch? Branch { get; set; }
        public Guid BranchId { get; set; }

        public ICollection<AuditLog>? AuditLogs { get; set; }
    }
}
