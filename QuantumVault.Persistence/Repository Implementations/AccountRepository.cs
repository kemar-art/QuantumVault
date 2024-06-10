using Microsoft.EntityFrameworkCore;
using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Application.Features.Queries.CustomerQuery.GetCustomer;
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

        public async Task<Account> UpdateCustomerAccount(Guid? id, int? accountNumber, decimal? depositAmount)
        {
            if (accountNumber == null || depositAmount == null)
            {
                throw new ArgumentException("Account number and deposit amount must be provided.");
            }

            var accountToUpdate = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == accountNumber.Value && a.Id == id);
            if (accountToUpdate == null)
            {
                throw new InvalidOperationException("Account not found.");
            }

            accountToUpdate.Balance += depositAmount.Value;
            //await _dbContext.SaveChangesAsync();
            return accountToUpdate;
        }


    }
}
