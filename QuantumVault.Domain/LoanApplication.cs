using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Domain;

public class LoanApplication
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public decimal Amount { get; set; }
    public DateTime ApplicationDate { get; set; }
    public string Status { get; set; } = string.Empty;

    [ForeignKey(nameof(CustomerId))]
    public Customer? Customer { get; set; }
    public string CustomerId { get; set; } = string.Empty;

    [ForeignKey(nameof(LoanTypeId))]
    public LoanType? LoanType { get; set; }
    public Guid LoanTypeId { get; set; }

    public ICollection<AuditLog>? AuditLogs { get; set; }
}
