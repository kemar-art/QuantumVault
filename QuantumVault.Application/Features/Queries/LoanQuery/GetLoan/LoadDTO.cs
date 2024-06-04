using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.LoanQuery.GetLoan
{
    public class LoadDTO
    {
        public Guid Id { get; set; } 
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Guid CustomerId { get; set; }

        public ICollection<LoanPayment>? Payments { get; set; }
        public ICollection<AuditLog>? AuditLogs { get; set; }
    }
}
