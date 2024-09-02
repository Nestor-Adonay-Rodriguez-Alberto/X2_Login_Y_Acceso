using Entidades;
using Logica_Negocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography;
using System.Text;

namespace UI_Login_Y_Acceso.Controllers
{
    [Authorize(Roles = "Director., Sub Director.")]
    public class ProfesorController : Controller
    {
        // Puente Para La DB:
        private readonly ProfesorBL _ProfesorBL;

        // Constuctor:
        public ProfesorController(ProfesorBL profesorBL)
        {
            _ProfesorBL = profesorBL;
        }


        // Manda Todos Los Objetos De La Tabla:
        public async Task<ActionResult> Index()
        {
            var Objetos_Obtenidos = await _ProfesorBL.Obtener_Todos();

            return View(Objetos_Obtenidos);
        }

        // Manda Un Objeto De La Tabla:
        public async Task<ActionResult> Details(int id)
        {
            var Objeto_Obtenido = await _ProfesorBL.Obtener_PorId(new Profesor() { IdProfesor = id });

            return View(Objeto_Obtenido);
        }

        public async Task<ActionResult> Create()
        {
            var Lista_Ciudades = await _ProfesorBL.Lista_Ciudades();
            var Lista_Roles = await _ProfesorBL.Lista_Roles();

            ViewData["Lista_Ciudades"] = new SelectList(Lista_Ciudades, "IdCiudad", "Nombre");
            ViewData["Lista_Roles"] = new SelectList(Lista_Roles, "IdRol", "Nombre");

            return View();
        }


        // Guarda El Objeto Del Parametro:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Profesor profesor, IFormFile Fotografia)
        {
            if (Fotografia != null && Fotografia.Length > 0)
            {
                var Cadena_Bytes = new MemoryStream();

                // Pasamos A Cadena De Byte;
                await Fotografia.CopyToAsync(Cadena_Bytes);

                // Pasamos A Arreglo De Bytes Y Guardamos En Objeto:
                profesor.Fotografia = Cadena_Bytes.ToArray();
            }

            // Encriptamos:
            profesor.Password = EncriptarMD5(profesor.Password);

            // Guardamos En La DB:
            await _ProfesorBL.Create(profesor);
            return RedirectToAction(nameof(Index));
        }


        // Manda Un Objeto De La Tabla:
        public async Task<ActionResult> Edit(int id)
        {
            var Objeto_Obtenido = await _ProfesorBL.Obtener_PorId(new Profesor() { IdProfesor = id });

            var Lista_Ciudades = await _ProfesorBL.Lista_Ciudades();
            var Lista_Roles = await _ProfesorBL.Lista_Roles();

            ViewData["Lista_Ciudades"] = new SelectList(Lista_Ciudades, "IdCiudad", "Nombre",Objeto_Obtenido.IdCiudadEnPersona);
            ViewData["Lista_Roles"] = new SelectList(Lista_Roles, "IdRol", "Nombre",Objeto_Obtenido.IdRolEnPersona);

            return View(Objeto_Obtenido);
        }


        // Manda El Objeto Y Lo Modifica:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Profesor profesor, IFormFile Fotografia)
        {
            var Objeto_Obtenido = await _ProfesorBL.Obtener_PorId(profesor);

            if (Fotografia != null && Fotografia.Length > 0)
            {
                var Cadena_Bytes = new MemoryStream();

                // Pasamos A Cadena De Byte;
                await Fotografia.CopyToAsync(Cadena_Bytes);

                // Pasamos A Arreglo De Bytes Y Guardamos En Objeto:
                profesor.Fotografia = Cadena_Bytes.ToArray();
            }
            else
            {
                profesor.Fotografia = Objeto_Obtenido.Fotografia;
            }

            if (profesor.Password!=null)
            {
                profesor.Password = EncriptarMD5(profesor.Password);
            }
            else
            {
                profesor.Password = Objeto_Obtenido.Password;
            }

            // Guardamos En DB:
            await _ProfesorBL.Edit(profesor);
            return RedirectToAction(nameof(Index));
        }


        // Manda El Objeto A VIsta
        public async Task<ActionResult> Delete(int id)
        {
            var Objeto_Obtenido = await _ProfesorBL.Obtener_PorId(new Profesor() { IdProfesor = id });

            return View(Objeto_Obtenido);
        }


        // Manda El Objeto Y Lo Elimina
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Profesor profesor)
        {
            await _ProfesorBL.Delete(profesor);
            return RedirectToAction(nameof(Index));
        }


        // Encripta Contraseñas:
        public string EncriptarMD5(string Password)
        {
            using (MD5 md5 = MD5.Create())
            {
                // Convertimos el texto en bytes antes de pasarlo al objeto MD5
                byte[] textoBytes = Encoding.UTF8.GetBytes(Password);

                // Calculamos el hash MD5
                byte[] hashBytes = md5.ComputeHash(textoBytes);

                // Convertimos el hash encriptado a su representación hexadecimal
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                // Retornamos el hash encriptado como cadena
                return sb.ToString();
            }
        }

    }
}
