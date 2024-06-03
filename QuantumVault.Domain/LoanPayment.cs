using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Domain;

public class LoanPayment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime PaymentDate { get; set; }
    public decimal PaymentAmount { get; set; }

    [ForeignKey("LoanId")]
    public Loan? Loan { get; set; }
    public Guid LoanId { get; set; }

    public ICollection<AuditLog>? AuditLogs { get; set; }
}
