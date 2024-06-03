using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application;

public static class QuantumVaultApplicationServiceRegistration
{
    public static IServiceCollection AddQuantumVaultApplicationService(this IServiceCollection serviceProvider)
    {
        serviceProvider.AddAutoMapper(Assembly.GetExecutingAssembly());
        serviceProvider.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return serviceProvider;
    }
}
