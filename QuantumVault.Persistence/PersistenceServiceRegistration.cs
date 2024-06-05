using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuantumVault.Application.Contracts;
using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Persistence.DatabaseContext;
using QuantumVault.Persistence.Repository_Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection serviceProvider, IConfiguration configuration) 
        {
            serviceProvider.AddDbContext<QuantumVaultDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("QuantumVaultSecureConnection"));
            });

            serviceProvider.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            serviceProvider.AddScoped<IBranchRepository, BranchRepository>();
            return serviceProvider;
        }
    }
}
