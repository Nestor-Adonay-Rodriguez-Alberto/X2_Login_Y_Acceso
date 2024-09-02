using Acceso_Datos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica_Negocio
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddBLDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDALDependecies(configuration);

            // Puente De La Tablas:
            services.AddScoped<RolBL>();
            services.AddScoped<CiudadBL>();
            services.AddScoped<ProfesorBL>();
            services.AddScoped<MateriaBL>();
            services.AddScoped<EstudianteBL>();
            services.AddScoped<SeguridadBL>();


            return services;
        }
    }
}
