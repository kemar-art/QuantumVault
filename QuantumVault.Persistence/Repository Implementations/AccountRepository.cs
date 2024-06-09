using Microsoft.EntityFrameworkCore;
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
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(QuantumVaultDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> GetByAccountNumberAsync(int accountNumber)
        {
            var account = await _dbContext.Accounts.FirstOrDefaultAsync(a  => a.AccountNumber == accountNumber);
            if (account != null)
            {
                return account.AccountNumber;
            }
            return 0;
        }
    }
}
