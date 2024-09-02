using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos
{
    public class MyDBContextFactory : IDesignTimeDbContextFactory<MyDBcontext>
    {
        public MyDBcontext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDBcontext>();
            const string Cadena_Conexion = "Data Source=.;Initial Catalog=X2_Login_Y_Acceso;Integrated Security=True;Trust Server Certificate=True";
            optionsBuilder.UseSqlServer(Cadena_Conexion);

            return new MyDBcontext(optionsBuilder.Options);
        }
    }
}
