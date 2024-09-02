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
    public class MateriaDAL
    {
        // Representa DB:
        private readonly MyDBcontext _MyDBcontext;

        // Constructor:
        public MateriaDAL(MyDBcontext myDBcontext)
        {
            _MyDBcontext = myDBcontext;
        }


        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********
        // **********************************************************

        // Manda Un Objeto Encontrado:
        public async Task<Materia> Obtener_PorId(Materia materia)
        {
            var Objeto_Obtenido = await _MyDBcontext.Materias
                .Include(x => x.Objeto_Profesor)
                .FirstOrDefaultAsync(x => x.IdMateria == materia.IdMateria);

            return Objeto_Obtenido;
        }

        // Manda Todos Los Objetos:
        public async Task<List<Materia>> Obtener_Todos()
        {
            var Objetos_Obtenidos = await _MyDBcontext.Materias
                .Include(x=> x.Objeto_Profesor)
                .ToListAsync();

            return Objetos_Obtenidos;
        }

        // Lista De La Tabla Profesores Para ViewData:
        public async Task<List<Profesor>> Lista_Profesores()
        {
            var Objetos_Obtenidos = await _MyDBcontext.Profesores.ToListAsync();

            return Objetos_Obtenidos;
        }




        // *******  METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB  ********
        // ********************************************************************

        // Recibe Un Objeto Lo Guarda En La DB:
        public async Task<int> Create(Materia materia)
        {
            _MyDBcontext.Add(materia);

            return await _MyDBcontext.SaveChangesAsync();
        }


        // Recibe Un Objeto Lo Busca Y Modifica El Encontrado Con El Nuevo:
        public async Task<int> Edit(Materia materia)
        {
            var Objeto_Obtenido = await _MyDBcontext.Materias.FirstOrDefaultAsync(x => x.IdMateria == materia.IdMateria);

            if (Objeto_Obtenido != null)
            {
                Objeto_Obtenido.Nombre = materia.Nombre;
                Objeto_Obtenido.Horario = materia.Horario;
                Objeto_Obtenido.IdProfesorEnMateria = materia.IdProfesorEnMateria;

                _MyDBcontext.Update(Objeto_Obtenido);
            }

            return await _MyDBcontext.SaveChangesAsync();
        }


        // Recibe Un Objeto Lo Busca Y Elimina El Encontrado:
        public async Task<int> Delete(Materia materia)
        {
            var Objeto_Obtenido = await _MyDBcontext.Materias.FirstOrDefaultAsync(x => x.IdMateria == materia.IdMateria);

            if (Objeto_Obtenido != null)
            {
                _MyDBcontext.Remove(Objeto_Obtenido);
            }

            return await _MyDBcontext.SaveChangesAsync();
        }


    }
}
