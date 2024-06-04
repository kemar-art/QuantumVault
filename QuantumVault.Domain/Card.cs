using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Domain;

public class Card
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CardNumber { get; set; } = string.Empty;
    public DateTime ExpiryDate { get; set; }

    [ForeignKey("CustomerId")]
    public Customer? Customer { get; set; }
    public Guid CustomerId { get; set; }

    [ForeignKey("CardTypeId")]
    public CardType? CardType { get; set; }
    public Guid CardTypeId { get; set; }

    public ICollection<AuditLog>? AuditLogs { get; set; }
}
