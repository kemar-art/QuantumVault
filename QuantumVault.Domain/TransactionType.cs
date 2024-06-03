using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace QuantumVault.Domain;

public class TransactionType
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string TypeName { get; set; } = string.Empty;
    public ICollection<Transaction>? Transactions { get; set; }
}
