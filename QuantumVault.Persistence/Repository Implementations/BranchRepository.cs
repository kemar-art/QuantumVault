using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using QuantumVault.Application.Contracts;
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
    public class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        public BranchRepository(QuantumVaultDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<int> GetBranchCountAsync()
        {
            var branchCount = await _dbContext.Branches.ToListAsync();
            return branchCount.Count;
        }
    }
}
