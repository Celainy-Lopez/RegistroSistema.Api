using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistemas.Data.Context;

namespace Sistemas.Data.DI;

public static class DbContextRegistrar
{
    public static IServiceCollection RegisterDbContextFactory(this IServiceCollection services)
    {
        services.AddDbContextFactory<SistemasContext>(o => o.UseSqlServer("Name=SqlConStr"));
        return services;
    }
}