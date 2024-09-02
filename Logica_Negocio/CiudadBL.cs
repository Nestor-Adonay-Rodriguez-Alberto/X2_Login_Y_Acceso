using Acceso_Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica_Negocio
{
    public class CiudadBL
    {
        // Tabla De La DB:
        private readonly CiudadDAL _CiudadDAL;

        // Constructor:
        public CiudadBL(CiudadDAL ciudadDAL)
        {
            _CiudadDAL = ciudadDAL;
        }


        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********
        // **********************************************************

        // Manda Un Objeto Encontrado:
        public async Task<Ciudad> Obtener_PorId(Ciudad ciudad)
        {
            return await _CiudadDAL.Obtener_PorId(ciudad);
        }


        // Manda Todos Los Objetos:
        public async Task<List<Ciudad>> Obtener_Todos()
        {
            return await _CiudadDAL.Obtener_Todos();
        }


        // *******  METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB  ********
        // ********************************************************************

        // Recibe Un Objeto Lo Guarda En La DB:
        public async Task<int> Create(Ciudad ciudad)
        {
            return await _CiudadDAL.Create(ciudad);
        }


        // Recibe Un Objeto Lo Busca Y Modifica El Encontrado Con El Nuevo:
        public async Task<int> Edit(Ciudad ciudad)
        {
            return await _CiudadDAL.Edit(ciudad);
        }


        // Recibe Un Objeto Lo Busca Y Elimina El Encontrado:
        public async Task<int> Delete(Ciudad ciudad)
        {
            return await _CiudadDAL.Delete(ciudad);
        }

    }
}
