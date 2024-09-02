using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos
{
    public class ProfesorDAL
    {
        // Representa DB:
        private readonly MyDBcontext _MyDBcontext;

        // Constructor:
        public ProfesorDAL(MyDBcontext myDBcontext)
        {
            _MyDBcontext = myDBcontext;
        }


        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********
        // **********************************************************

        // Manda Un Objeto Encontrado:
        public async Task<Profesor> Obtener_PorId(Profesor profesor)
        {
            var Objeto_Obtenido = await _MyDBcontext.Profesores
                .Include(x=> x.Objeto_Ciudad)
                .Include(x => x.Objeto_Rol)
                .FirstOrDefaultAsync(x => x.IdProfesor == profesor.IdProfesor);

            return Objeto_Obtenido;
        }

        // Manda Todos Los Objetos:
        public async Task<List<Profesor>> Obtener_Todos()
        {
            var Objetos_Obtenidos = await _MyDBcontext.Profesores
                .Include(x=> x.Objeto_Ciudad)
                .Include(x => x.Objeto_Rol)
                .ToListAsync();

            return Objetos_Obtenidos;
        }

        // Lista De La Tabla Ciudades Para ViewData:
        public async Task<List<Ciudad>> Lista_Ciudades()
        {
            var Objetos_Obtenidos = await _MyDBcontext.Ciudades.ToListAsync();

            return Objetos_Obtenidos;
        }

        // Lista De La Tabla Roles Para ViewData:
        public async Task<List<Rol>> Lista_Roles()
        {
            var Objetos_Obtenidos = await _MyDBcontext.Roles.ToListAsync();

            return Objetos_Obtenidos;
        }



        // *******  METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB  ********
        // ********************************************************************

        // Recibe Un Objeto Lo Guarda En La DB:
        public async Task<int> Create(Profesor profesor)
        {
            _MyDBcontext.Add(profesor);

            return await _MyDBcontext.SaveChangesAsync();
        }


        // Recibe Un Objeto Lo Busca Y Modifica El Encontrado Con El Nuevo:
        public async Task<int> Edit(Profesor profesor)
        {
            var Objeto_Obtenido = await _MyDBcontext.Profesores.FirstOrDefaultAsync(x => x.IdProfesor == profesor.IdProfesor);

            if (Objeto_Obtenido != null)
            {
                Objeto_Obtenido.Nombre = profesor.Nombre;
                Objeto_Obtenido.Apellidos = profesor.Apellidos;
                Objeto_Obtenido.Aula = profesor.Aula;
                Objeto_Obtenido.Email = profesor.Email;
                Objeto_Obtenido.Password = profesor.Password;
                Objeto_Obtenido.Fotografia = profesor.Fotografia;
                Objeto_Obtenido.IdCiudadEnPersona = profesor.IdCiudadEnPersona;
                Objeto_Obtenido.IdRolEnPersona = profesor.IdRolEnPersona;
                
                _MyDBcontext.Update(Objeto_Obtenido);
            }

            return await _MyDBcontext.SaveChangesAsync();
        }


        // Recibe Un Objeto Lo Busca Y Elimina El Encontrado:
        public async Task<int> Delete(Profesor profesor)
        {
            var Objeto_Obtenido = await _MyDBcontext.Profesores.FirstOrDefaultAsync(x => x.IdProfesor == profesor.IdProfesor);

            if (Objeto_Obtenido != null)
            {
                _MyDBcontext.Remove(Objeto_Obtenido);
            }

            return await _MyDBcontext.SaveChangesAsync();
        }

    }
}
