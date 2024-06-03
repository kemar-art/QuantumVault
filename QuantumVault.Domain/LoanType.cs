using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Domain;

public class LoanType
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string TypeName { get; set; } = string.Empty;
    public ICollection<LoanApplication>? LoanApplications { get; set; }
}
