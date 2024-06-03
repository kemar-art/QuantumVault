using MediatR;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.AccountCommands.CreateAccount
{
    public class CreateAccountCommand : IRequest<Guid>
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedDate { get; set; }

        public Guid CustomerId { get; set; }

        public Guid BranchId { get; set; }

        public Guid AccountTypeId { get; set; }

        public ICollection<Transaction>? Transactions { get; set; }
        public ICollection<AuditLog>? AuditLogs { get; set; }
    }
}
