using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Domain;

public class Transaction
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }
    public string Description { get; set; } = string.Empty;

    [ForeignKey(nameof(AccountId))]
    public Account? Account { get; set; }
    public Guid AccountId { get; set; }

    [ForeignKey(nameof(TransactionTypeId))]
    public TransactionType? TransactionType { get; set; }
    public Guid TransactionTypeId { get; set; }

    public ICollection<AuditLog> AuditLogs { get; set; }
}
