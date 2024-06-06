using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuantumVault.Application.Contracts.ILogger;
using QuantumVault.Infrastructure.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Infrastructure
{
    public static class QuantumVaultInfrastructureServiceRegistration
    {
        public static IServiceCollection AddQuantumVaultInfrastructureService(this IServiceCollection serviceProvider, IConfiguration configuration)
        {
            serviceProvider.AddScoped(typeof(IAppLogger<>), typeof(AppLogger<>));

            return serviceProvider;
        }
    }
}
