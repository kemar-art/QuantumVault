using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Domain;
using QuantumVault.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Persistence.Repository_Implementations
{
    public class CardTypeRepository : GenericRepository<CardType>, ICardTypeRepository
    {
        public CardTypeRepository(QuantumVaultDbContext dbContext) : base(dbContext)
        {
        }
    }
}
