using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Domain;

public class Loan
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public decimal Amount { get; set; }
    public decimal InterestRate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public Customer? Customer { get; set; }
    public string CustomerId { get; set; } = string.Empty;

    public ICollection<LoanPayment>? Payments { get; set; }
    public ICollection<AuditLog>? AuditLogs { get; set; }
}
