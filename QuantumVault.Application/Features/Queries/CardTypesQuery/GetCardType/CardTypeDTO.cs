using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.CardTypesQuery.GetCardType
{
    public class CardTypeDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string TypeName { get; set; } = string.Empty;
    }
}
