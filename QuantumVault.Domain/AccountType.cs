 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Domain;

public class AccountType
{
    [Key]
    public Guid Id { get; set; }
    public string TypeName { get; set; } = string.Empty;
}
