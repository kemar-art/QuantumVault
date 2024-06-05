using Microsoft.EntityFrameworkCore;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Persistence.DatabaseContext
{
    public class QuantumVaultDbContext : DbContext
    {
        public QuantumVaultDbContext(DbContextOptions<QuantumVaultDbContext> options) : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<LoanApplication> LoanApplications { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanPayment> LoanPayments { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<LoanType> LoanTypes { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
    }
}
