﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Domain;

public class Card
{
    public string Id { get; set; } 
    public string CardNumber { get; set; } = string.Empty;
    public DateTime ExpiryDate { get; set; }

    [ForeignKey("CustomerId")]
    public Customer? Customer { get; set; }
    public Guid CustomerId { get; set; }

    [ForeignKey("CardTypeId")]
    public CardType? CardType { get; set; }
    public int CardTypeId { get; set; }

    public ICollection<AuditLog>? AuditLogs { get; set; }
}
