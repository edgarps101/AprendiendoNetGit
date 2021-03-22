using Microsoft.Extensions.DependencyInjection;
using Negocios;
using Servicios.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios
{
    public static class Kernel
    {
        public static IServiceCollection RegistrarServicios(this IServiceCollection services)
        {
            services.AddTransient<IAutoServicio, AutoServicios>();
            services.RegistrarNegocios();
            return services;
        }
    }
}
