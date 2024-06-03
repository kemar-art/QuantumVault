using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.Account.GetAccount
{
    public class AccountTypeDTO
    {
        public Guid Id { get; set; }
        public string TypeName { get; set; } = string.Empty;
    }
}
