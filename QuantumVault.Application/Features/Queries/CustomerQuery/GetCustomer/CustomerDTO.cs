﻿using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.CustomerQuery.GetCustomer
{
    public class CustomerDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
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
}