using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.CustomerQuery.GetCustomer
{
    public class CustomerAccountDTO
    {
        public Guid Id { get; set; }
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedDate { get; set; }
        public string BranchName { get; set; } = string.Empty;
    }
}
