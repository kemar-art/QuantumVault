﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Domain;

public class Account
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AccountNumber { get; set; }
    public decimal Balance { get; set; }
    public decimal Deposit { get; set; }
    public DateTime CreatedDate { get; set; }

    [ForeignKey(nameof(CustomerId))] 
    public Customer? Customer { get; set; }
    public Guid CustomerId { get; set; }

    [ForeignKey(nameof(BranchId))]
    public Branch? Branch { get; set; }
    public Guid BranchId { get; set; }

    public ICollection<Transaction>? Transactions { get; set; }
    public ICollection<AuditLog>? AuditLogs { get; set; }
}
