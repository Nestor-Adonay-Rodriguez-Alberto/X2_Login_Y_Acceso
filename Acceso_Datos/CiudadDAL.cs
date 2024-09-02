using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos
{
    public class CiudadDAL
    {
        // Representa DB:
        private readonly MyDBcontext _MyDBcontext;

        // Constructor:
        public CiudadDAL(MyDBcontext myDBcontext)
        {
            _MyDBcontext = myDBcontext;
        }


        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********
        // **********************************************************

        // Manda Un Objeto Encontrado:
        public async Task<Ciudad> Obtener_PorId(Ciudad ciudad)
        {
            var Objeto_Obtenido = await _MyDBcontext.Ciudades.FirstOrDefaultAsync(x => x.IdCiudad == ciudad.IdCiudad);

            return Objeto_Obtenido;
        }

        // Manda Todos Los Objetos:
        public async Task<List<Ciudad>> Obtener_Todos()
        {
            var Objetos_Obtenidos = await _MyDBcontext.Ciudades.ToListAsync();

            return Objetos_Obtenidos;
        }


        // *******  METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB  ********
        // ********************************************************************

        // Recibe Un Objeto Lo Guarda En La DB:
        public async Task<int> Create(Ciudad ciudad)
        {
            _MyDBcontext.Add(ciudad);

            return await _MyDBcontext.SaveChangesAsync();
        }


        // Recibe Un Objeto Lo Busca Y Modifica El Encontrado Con El Nuevo:
        public async Task<int> Edit(Ciudad ciudad)
        {
            var Objeto_Obtenido = await _MyDBcontext.Ciudades.FirstOrDefaultAsync(x => x.IdCiudad == ciudad.IdCiudad);

            if (Objeto_Obtenido != null)
            {
                Objeto_Obtenido.Nombre = ciudad.Nombre;

                _MyDBcontext.Update(Objeto_Obtenido);
            }

            return await _MyDBcontext.SaveChangesAsync();
        }


        // Recibe Un Objeto Lo Busca Y Elimina El Encontrado:
        public async Task<int> Delete(Ciudad ciudad)
        {
            var Objeto_Obtenido = await _MyDBcontext.Ciudades.FirstOrDefaultAsync(x => x.IdCiudad == ciudad.IdCiudad);

            if (Objeto_Obtenido != null)
            {
                _MyDBcontext.Remove(Objeto_Obtenido);
            }

            return await _MyDBcontext.SaveChangesAsync();
        }
    }
}
