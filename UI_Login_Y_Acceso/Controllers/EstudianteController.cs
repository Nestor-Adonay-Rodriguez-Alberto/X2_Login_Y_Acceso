using Acceso_Datos;
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
    [Authorize]
    public class EstudianteController : Controller
    {
        // Puente Para La DB:
        private readonly EstudianteBL _EstudianteBL;

        // Constuctor:
        public EstudianteController(EstudianteBL estudianteBL)
        {
            _EstudianteBL = estudianteBL;
        }


        // Manda Todos Los Objetos De La Tabla:
        public async Task<ActionResult> Index()
        {
            var Objetos_Obtenidos = await _EstudianteBL.Obtener_Todos();

            return View(Objetos_Obtenidos);
        }

        // Manda Un Objeto De La Tabla:
        public async Task<ActionResult> Details(int id)
        {
            var Objeto_Obtenido = await _EstudianteBL.Obtener_PorId(new Estudiante() { IdEstudiante = id });

            return View(Objeto_Obtenido);
        }

        public async Task<ActionResult> Create()
        {
            var Lista_Materias = await _EstudianteBL.Lista_Materias();

            ViewData["Lista_Materias"] = new SelectList(Lista_Materias, "IdMateria", "Nombre");

            return View();
        }


        // Guarda El Objeto Del Parametro:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Estudiante estudiante, IFormFile Fotografia)
        {
            if (Fotografia != null && Fotografia.Length > 0)
            {
                var Cadena_Bytes = new MemoryStream();

                // Pasamos A Cadena De Byte;
                await Fotografia.CopyToAsync(Cadena_Bytes);

                // Pasamos A Arreglo De Bytes Y Guardamos En Objeto:
                estudiante.Fotografia = Cadena_Bytes.ToArray();
            }

            // Encriptamos:
            estudiante.Password = EncriptarMD5(estudiante.Password);

            // Guardamos En La DB:
            await _EstudianteBL.Create(estudiante);
            return RedirectToAction(nameof(Index));
        }


        // Manda Un Objeto De La Tabla:
        public async Task<ActionResult> Edit(int id)
        {
            var Objeto_Obtenido = await _EstudianteBL.Obtener_PorId(new Estudiante() { IdEstudiante = id });

            var Lista_Materias = await _EstudianteBL.Lista_Materias();

            ViewData["Lista_Materias"] = new SelectList(Lista_Materias, "IdMateria", "Nombre", Objeto_Obtenido.IdMateriaEnEstudiante);

            return View(Objeto_Obtenido);
        }


        // Manda El Objeto Y Lo Modifica:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Estudiante estudiante, IFormFile Fotografia)
        {
            var Objeto_Obtenido = await _EstudianteBL.Obtener_PorId(estudiante);


            if (Fotografia != null && Fotografia.Length > 0)
            {
                var Cadena_Bytes = new MemoryStream();

                // Pasamos A Cadena De Byte;
                await Fotografia.CopyToAsync(Cadena_Bytes);

                // Pasamos A Arreglo De Bytes Y Guardamos En Objeto:
                estudiante.Fotografia = Cadena_Bytes.ToArray();
            }
            else
            {
                estudiante.Fotografia = Objeto_Obtenido.Fotografia;
            }

            estudiante.Password = Objeto_Obtenido.Password;

            // Guardamos En DB:
            await _EstudianteBL.Edit(estudiante);
            return RedirectToAction(nameof(Index));
        }


        // Manda El Objeto A VIsta
        public async Task<ActionResult> Delete(int id)
        {
            var Objeto_Obtenido = await _EstudianteBL.Obtener_PorId(new Estudiante() { IdEstudiante = id });

            return View(Objeto_Obtenido);
        }


        // Manda El Objeto Y Lo Elimina
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Estudiante estudiante)
        {
            await _EstudianteBL.Delete(estudiante);
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
