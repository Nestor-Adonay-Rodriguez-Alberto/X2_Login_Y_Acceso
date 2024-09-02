using Acceso_Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica_Negocio
{
    public class EstudianteBL
    {
        // Tabla De La DB:
        private readonly EstudianteDAL _EstudianteDAL;

        // Constructor:
        public EstudianteBL(EstudianteDAL estudianteDAL)
        {
            _EstudianteDAL = estudianteDAL;
        }


        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********
        // **********************************************************

        // Manda Un Objeto Encontrado:
        public async Task<Estudiante> Obtener_PorId(Estudiante estudiante)
        {
            return await _EstudianteDAL.Obtener_PorId(estudiante);
        }


        // Manda Todos Los Objetos:
        public async Task<List<Estudiante>> Obtener_Todos()
        {
            return await _EstudianteDAL.Obtener_Todos();
        }

        // Lista De La Tabla Ciudades Para ViewData:
        public async Task<List<Materia>> Lista_Materias()
        {
            return await _EstudianteDAL.Lista_Materias();
        }




        // *******  METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB  ********
        // ********************************************************************

        // Recibe Un Objeto Lo Guarda En La DB:
        public async Task<int> Create(Estudiante estudiante)
        {
            return await _EstudianteDAL.Create(estudiante);
        }


        // Recibe Un Objeto Lo Busca Y Modifica El Encontrado Con El Nuevo:
        public async Task<int> Edit(Estudiante estudiante)
        {
            return await _EstudianteDAL.Edit(estudiante);
        }


        // Recibe Un Objeto Lo Busca Y Elimina El Encontrado:
        public async Task<int> Delete(Estudiante estudiante)
        {
            return await _EstudianteDAL.Delete(estudiante);
        }

    }
}
