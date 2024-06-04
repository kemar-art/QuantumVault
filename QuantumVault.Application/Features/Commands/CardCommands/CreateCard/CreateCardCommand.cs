using MediatR;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.CardCommands.CreateCard
{
    public class CreateCardCommand : IRequest<Guid>
    {
        public string CardNumber { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }

        public Guid CustomerId { get; set; }

        public int CardTypeId { get; set; }

        public ICollection<AuditLog>? AuditLogs { get; set; }
    }
}
