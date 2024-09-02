using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos
{
    public class SeguridadDAL
    {
        // Representa DB:
        private readonly MyDBcontext _MyDBcontext;

        // Constructor:
        public SeguridadDAL(MyDBcontext myDBcontext)
        {
            _MyDBcontext = myDBcontext;
        }


        // Manda Un Objeto:
        public async Task<Profesor> Creadenciales_Profesor(Profesor profesor)
        {
            var Objeto_Obtenido = await _MyDBcontext.Profesores
                .Include(x => x.Objeto_Ciudad)
                .Include(x => x.Objeto_Rol)
                .FirstOrDefaultAsync(s => s.Email == profesor.Email && s.Password == profesor.Password);

            return Objeto_Obtenido;
        }
    }
}
