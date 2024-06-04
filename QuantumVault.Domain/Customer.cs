using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Domain;

public class Customer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty ;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Occupation { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public ICollection<Account>? Accounts { get; set; }
    public ICollection<LoanApplication>? LoanApplications { get; set; }
    public ICollection<Loan>? Loans { get; set; }
    public ICollection<Card>? Cards { get; set; }
    public ICollection<AuditLog>? AuditLogs { get; set; }
}
