using AutoMapper;
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
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly IMapper _mapper;

        public CustomerRepository(QuantumVaultDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<Customer> GetByAccountNumberAsync(int? accountNumber)
        {
            if (accountNumber == null)
                return null;

            return await _dbContext.Customers
                .Include(c => c.Accounts)
                .ThenInclude(a => a.Branch)
                .FirstOrDefaultAsync(c => c.Accounts.Any(a => a.AccountNumber == accountNumber));
        }


        public async Task<Customer> GetByEmailAsync(string email)
        {
            return await _dbContext.Customers
                .Include(c => c.Accounts)
                .ThenInclude(a => a.Branch)
                .FirstOrDefaultAsync(e => e.Email == email);
        }

    }
}

