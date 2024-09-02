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
    public class EstudianteDAL
    {
        // Representa DB:
        private readonly MyDBcontext _MyDBcontext;

        // Constructor:
        public EstudianteDAL(MyDBcontext myDBcontext)
        {
            _MyDBcontext = myDBcontext;
        }


        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********
        // **********************************************************

        // Manda Un Objeto Encontrado:
        public async Task<Estudiante> Obtener_PorId(Estudiante estudiante)
        {
            var Objeto_Obtenido = await _MyDBcontext.Estudiantes
                .Include(x=> x.Objeto_Materia)
                .ThenInclude(x=> x.Objeto_Profesor)
                .FirstOrDefaultAsync(x => x.IdEstudiante == estudiante.IdEstudiante);

            return Objeto_Obtenido;
        }

        // Manda Todos Los Objetos:
        public async Task<List<Estudiante>> Obtener_Todos()
        {

            var Objetos_Obtenidos = await _MyDBcontext.Estudiantes
                .Include(x => x.Objeto_Materia)
                .ThenInclude(x => x.Objeto_Profesor)
                .ToListAsync();

            return Objetos_Obtenidos;
        }

        // Lista De La Tabla Ciudades Para ViewData:
        public async Task<List<Materia>> Lista_Materias()
        {
            var Objetos_Obtenidos = await _MyDBcontext.Materias
                .Include(x => x.Objeto_Profesor)
                .ToListAsync();

            return Objetos_Obtenidos;
        }




        // *******  METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB  ********
        // ********************************************************************

        // Recibe Un Objeto Lo Guarda En La DB:
        public async Task<int> Create(Estudiante estudiante)
        {
            _MyDBcontext.Add(estudiante);

            return await _MyDBcontext.SaveChangesAsync();
        }


        // Recibe Un Objeto Lo Busca Y Modifica El Encontrado Con El Nuevo:
        public async Task<int> Edit(Estudiante estudiante)
        {
            var Objeto_Obtenido = await _MyDBcontext.Estudiantes.FirstOrDefaultAsync(x => x.IdEstudiante == estudiante.IdEstudiante);

            if (Objeto_Obtenido != null)
            {
                Objeto_Obtenido.Nombre = estudiante.Nombre;
                Objeto_Obtenido.Apellidos = estudiante.Apellidos;
                Objeto_Obtenido.Email = estudiante.Email;
                Objeto_Obtenido.Password = estudiante.Password;
                Objeto_Obtenido.Fotografia = estudiante.Fotografia;
                Objeto_Obtenido.Telefono = estudiante.Telefono;
                Objeto_Obtenido.IdMateriaEnEstudiante = estudiante.IdMateriaEnEstudiante;

                _MyDBcontext.Update(Objeto_Obtenido);
            }

            return await _MyDBcontext.SaveChangesAsync();
        }


        // Recibe Un Objeto Lo Busca Y Elimina El Encontrado:
        public async Task<int> Delete(Estudiante estudiante)
        {
            var Objeto_Obtenido = await _MyDBcontext.Estudiantes.FirstOrDefaultAsync(x => x.IdEstudiante == estudiante.IdEstudiante);

            if (Objeto_Obtenido != null)
            {
                _MyDBcontext.Remove(Objeto_Obtenido);
            }

            return await _MyDBcontext.SaveChangesAsync();
        }

    }
}
