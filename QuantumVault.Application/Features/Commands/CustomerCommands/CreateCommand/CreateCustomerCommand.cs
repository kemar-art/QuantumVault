using MediatR;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.CustomerCommands.CreateCommand
{
    public class CreateCustomerCommand : IRequest<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Occupation { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public decimal OpeningBalance { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
