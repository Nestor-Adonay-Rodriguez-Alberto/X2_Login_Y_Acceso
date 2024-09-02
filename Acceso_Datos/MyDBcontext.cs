using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos
{
    public class MyDBcontext: DbContext
    {
        // Constructor
        public MyDBcontext(DbContextOptions<MyDBcontext> options)
            :base(options)
        {

        }

        // Tablas De DB:
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }

    }
}
