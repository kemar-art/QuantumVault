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
        public static IServiceCollection AddQuantumVaultPersistenceService(this IServiceCollection serviceProvider, IConfiguration configuration) 
        {
            serviceProvider.AddDbContext<QuantumVaultDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("QuantumVaultSecureConnection"));
            });

            serviceProvider.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            serviceProvider.AddScoped<IBranchRepository, BranchRepository>();
            serviceProvider.AddScoped<IAccountRepository, AccountRepository>();
            serviceProvider.AddScoped<IAccountTypeRepository, AccountTypeRepository>();
            serviceProvider.AddScoped<ICardRepository, CardRepository>();
            serviceProvider.AddScoped<ICardTypeRepository, CardTypeRepository>();
            serviceProvider.AddScoped<ICustomerRepository, CustomerRepository>();
            serviceProvider.AddScoped<IEmployeeRepository, EmployeeRepository>();
            serviceProvider.AddScoped<ILoanRepository, LoanRepository>();
            serviceProvider.AddScoped<ITransactionRepository, TransactionRepository>();
            return serviceProvider;
        }
    }
}
