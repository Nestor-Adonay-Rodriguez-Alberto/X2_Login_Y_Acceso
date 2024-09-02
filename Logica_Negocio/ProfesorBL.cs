using Acceso_Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica_Negocio
{
    public class ProfesorBL
    {
        // Tabla De La DB:
        private readonly ProfesorDAL _ProfesorDAL;

        // Constructor:
        public ProfesorBL(ProfesorDAL profesorDAL)
        {
            _ProfesorDAL = profesorDAL;
        }


        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********
        // **********************************************************

        // Manda Un Objeto Encontrado:
        public async Task<Profesor> Obtener_PorId(Profesor profesor)
        {
            return await _ProfesorDAL.Obtener_PorId(profesor);
        }


        // Manda Todos Los Objetos:
        public async Task<List<Profesor>> Obtener_Todos()
        {
            return await _ProfesorDAL.Obtener_Todos();
        }


        // Lista De La Tabla Ciudades Para ViewData:
        public async Task<List<Ciudad>> Lista_Ciudades()
        {
            return await _ProfesorDAL.Lista_Ciudades();
        }


        // Lista De La Tabla Roles Para ViewData:
        public async Task<List<Rol>> Lista_Roles()
        {
            return await _ProfesorDAL.Lista_Roles();
        }



        // *******  METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB  ********
        // ********************************************************************

        // Recibe Un Objeto Lo Guarda En La DB:
        public async Task<int> Create(Profesor profesor)
        {
            return await _ProfesorDAL.Create(profesor);
        }


        // Recibe Un Objeto Lo Busca Y Modifica El Encontrado Con El Nuevo:
        public async Task<int> Edit(Profesor profesor)
        {
            return await _ProfesorDAL.Edit(profesor);
        }


        // Recibe Un Objeto Lo Busca Y Elimina El Encontrado:
        public async Task<int> Delete(Profesor profesor)
        {
            return await _ProfesorDAL.Delete(profesor);
        }

    }
}
