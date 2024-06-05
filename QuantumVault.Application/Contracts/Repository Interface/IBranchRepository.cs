using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Contracts.Repository_Interface
{
    public interface IBranchRepository : IGenericRepository<Branch>
    {
        Task <int> GetBranchCountAsync();
    }
}
