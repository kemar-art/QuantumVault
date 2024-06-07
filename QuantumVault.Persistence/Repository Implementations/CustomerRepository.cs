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
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(QuantumVaultDbContext dbContext) : base(dbContext)
        {
        }

        public async Task GetByAccountNumberAsync(string accountNumber)
        {
            if (string.IsNullOrEmpty(accountNumber))
           await _dbContext.Accounts.FindAsync(accountNumber);

            return;
        }

        public Task GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
