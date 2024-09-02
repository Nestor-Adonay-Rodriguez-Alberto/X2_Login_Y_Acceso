using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddDALDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            // Inyeccion
            services.AddDbContext<MyDBcontext>(options => options.UseSqlServer(configuration.GetConnectionString("Cadena_Conexion")));

            // Accesos A Las Tablas
            services.AddScoped<RolDAL>();
            services.AddScoped<CiudadDAL>();
            services.AddScoped<ProfesorDAL>();
            services.AddScoped<MateriaDAL>();
            services.AddScoped<EstudianteDAL>();
            services.AddScoped<SeguridadDAL>();


            return services;
        }
    }
}
