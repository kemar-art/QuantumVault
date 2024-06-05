using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.CustomerQuery.GetAllCustomers
{
    public class AllCustomersDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Occupation { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public decimal OpenninmgBalance { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
