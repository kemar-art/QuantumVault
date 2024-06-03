using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Domain;

public class AuditLog
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string ActionType { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime ActionDate { get; set; }
    public string PerformedBy { get; set; } = string.Empty;
}
