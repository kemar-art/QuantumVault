 using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Domain;

public class AccountType
{
    public Guid Id { get; set; }
    public string TypeName { get; set; } = string.Empty;
}
