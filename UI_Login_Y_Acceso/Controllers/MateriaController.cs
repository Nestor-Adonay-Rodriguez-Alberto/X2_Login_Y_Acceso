
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
    public class MateriaController : Controller
    {
        // Puente Para La DB:
        private readonly MateriaBL _MateriaBL;

        // Constuctor:
        public MateriaController(MateriaBL materiaBL)
        {
            _MateriaBL = materiaBL;
        }


        // Manda Todos Los Objetos De La Tabla:
        public async Task<ActionResult> Index()
        {
            var Objetos_Obtenidos = await _MateriaBL.Obtener_Todos();

            return View(Objetos_Obtenidos);
        }

        // Manda Un Objeto De La Tabla:
        public async Task<ActionResult> Details(int id)
        {
            var Objeto_Obtenido = await _MateriaBL.Obtener_PorId(new Materia() { IdMateria = id });

            return View(Objeto_Obtenido);
        }

        public async Task<ActionResult> Create()
        {
            var Lista_Profesores = await _MateriaBL.Lista_Profesores();

            ViewData["Lista_Profesores"] = new SelectList(Lista_Profesores, "IdProfesor", "Nombre");

            return View();
        }


        // Guarda El Objeto Del Parametro:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Materia materia)
        {
            // Guardamos En La DB:
            await _MateriaBL.Create(materia);
            return RedirectToAction(nameof(Index));
        }


        // Manda Un Objeto De La Tabla:
        public async Task<ActionResult> Edit(int id)
        {
            var Objeto_Obtenido = await _MateriaBL.Obtener_PorId(new Materia() { IdMateria = id });

            var Lista_Profesores = await _MateriaBL.Lista_Profesores();

            ViewData["Lista_Profesores"] = new SelectList(Lista_Profesores, "IdProfesor", "Nombre", Objeto_Obtenido.IdProfesorEnMateria);

            return View(Objeto_Obtenido);
        }


        // Manda El Objeto Y Lo Modifica:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Materia materia)
        {
            // Guardamos En DB:
            await _MateriaBL.Edit(materia);
            return RedirectToAction(nameof(Index));
        }


        // Manda El Objeto A VIsta
        public async Task<ActionResult> Delete(int id)
        {
            var Objeto_Obtenido = await _MateriaBL.Obtener_PorId(new Materia() { IdMateria = id });

            return View(Objeto_Obtenido);
        }


        // Manda El Objeto Y Lo Elimina
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Materia materia)
        {
            await _MateriaBL.Delete(materia);
            return RedirectToAction(nameof(Index));
        }

    }
}
