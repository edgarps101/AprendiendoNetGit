using Microsoft.Extensions.DependencyInjection;
using Negocio;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocios
{
    public static class Kernel
    {
        public static IServiceCollection RegistrarNegocios(this IServiceCollection services)
        {
            services.AddTransient<IAutoNegocio, AutoNegocio>();
            return services;
        }
    }
}
