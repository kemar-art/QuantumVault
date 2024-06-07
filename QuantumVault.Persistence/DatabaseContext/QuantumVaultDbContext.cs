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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Specify precision and scale for decimal properties
            modelBuilder.Entity<Account>()
                .Property(a => a.Balance)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Customer>()
                .Property(c => c.OpeningBalance)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Loan>()
                .Property(l => l.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Loan>()
                .Property(l => l.InterestRate)
                .HasPrecision(18, 2);

            modelBuilder.Entity<LoanApplication>()
                .Property(la => la.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<LoanPayment>()
                .Property(lp => lp.PaymentAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasPrecision(18, 2);

            // Other model configuration
            base.OnModelCreating(modelBuilder);
        }
    }
}

