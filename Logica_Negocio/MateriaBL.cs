using Acceso_Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica_Negocio
{
    public class MateriaBL
    {
        // Tabla De La DB:
        private readonly MateriaDAL _MateriaDAL;

        // Constructor:
        public MateriaBL(MateriaDAL materiaDAL)
        {
            _MateriaDAL = materiaDAL;
        }


        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********
        // **********************************************************

        // Manda Un Objeto Encontrado:
        public async Task<Materia> Obtener_PorId(Materia materia)
        {
            return await _MateriaDAL.Obtener_PorId(materia);
        }


        // Manda Todos Los Objetos:
        public async Task<List<Materia>> Obtener_Todos()
        {
            return await _MateriaDAL.Obtener_Todos();
        }


        // Lista De La Tabla Profesores Para ViewData:
        public async Task<List<Profesor>> Lista_Profesores()
        {
            return await _MateriaDAL.Lista_Profesores();
        }





        // *******  METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB  ********
        // ********************************************************************

        // Recibe Un Objeto Lo Guarda En La DB:
        public async Task<int> Create(Materia materia)
        {
            return await _MateriaDAL.Create(materia);
        }


        // Recibe Un Objeto Lo Busca Y Modifica El Encontrado Con El Nuevo:
        public async Task<int> Edit(Materia materia)
        {
            return await _MateriaDAL.Edit(materia);
        }


        // Recibe Un Objeto Lo Busca Y Elimina El Encontrado:
        public async Task<int> Delete(Materia materia)
        {
            return await _MateriaDAL.Delete(materia);
        }

    }
}
