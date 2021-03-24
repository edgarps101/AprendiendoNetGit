using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public static class Kernel
    {
        public static IServiceCollection RegistrarDatos(this IServiceCollection services)
        {
            services.AddTransient<ConexionDB>();
            return services;
        }
    }
}
