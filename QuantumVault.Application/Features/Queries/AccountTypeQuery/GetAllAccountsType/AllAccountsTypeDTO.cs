using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.AccountTypeQuery.GetAllAccountsType
{
    public class AllAccountsTypeDTO
    {
        public int AccountNumber { get; set; }
        public string TypeName { get; set; } = string.Empty;

    }
}
