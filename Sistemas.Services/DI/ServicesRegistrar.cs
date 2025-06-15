using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistemas.Abstractions;
using Sistemas.Data.DI;

namespace Sistemas.Services.DI;

public static class ServicesRegistrar
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.RegisterDbContextFactory();
        services.AddScoped<ISistemasService, SistemasService>();
        return services;
    }

}
