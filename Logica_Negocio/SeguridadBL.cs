﻿using Acceso_Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica_Negocio
{
    public class SeguridadBL
    {
        // Representa Objeto DB:
        private readonly SeguridadDAL _SeguridadDAL;

        // Constructor:
        public SeguridadBL(SeguridadDAL seguridadDAL)
        {
            _SeguridadDAL = seguridadDAL;
        }

        // Manda Un Objeto:
        public async Task<Profesor> Creadenciales_Profesor(Profesor profesor)
        {
            return await _SeguridadDAL.Creadenciales_Profesor(profesor);
        }
    }
}
