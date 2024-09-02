using Logica_Negocio;
using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace UI_Login_Y_Acceso.Controllers
{
    [Authorize(Roles = "Director., Sub Director.")]
    public class RolController : Controller
    {
        // Puente Para La DB:
        private readonly RolBL _RolBL;

        // Constuctor:
        public RolController(RolBL rolBL)
        {
            _RolBL = rolBL;
        }


        // Manda Todos Los Objetos De La Tabla:
        public async Task<ActionResult> Index()
        {
            var Objetos_Obtenidos = await _RolBL.Obtener_Todos(); 

            return View(Objetos_Obtenidos);
        }

        // Manda Un Objeto De La Tabla:
        public async Task<ActionResult> Details(int id)
        {
            var Objeto_Obtenido = await _RolBL.Obtener_PorId(new Rol() { IdRol = id });

            return View(Objeto_Obtenido);
        }

        public ActionResult Create()
        {
            return View();
        }


        // Guarda El Objeto Del Parametro:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Rol rol)
        {
            await _RolBL.Create(rol);

            return RedirectToAction(nameof(Index));
        }


        // Manda Un Objeto De La Tabla:
        public async Task<ActionResult> Edit(int id)
        {
            var Objeto_Obtenido = await _RolBL.Obtener_PorId(new Rol() { IdRol = id });

            return View(Objeto_Obtenido);
        }


        // Manda El Objeto Y Lo Modifica:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Rol rol)
        {
            await _RolBL.Edit(rol);

            return RedirectToAction(nameof(Index));
        }


        // Manda El Objeto A VIsta
        public async Task<ActionResult> Delete(int id)
        {
            var Objeto_Obtenido = await _RolBL.Obtener_PorId(new Rol() { IdRol = id });

            return View(Objeto_Obtenido);
        }


        // Manda El Objeto Y Lo Elimina
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Rol rol)
        {
            await _RolBL.Delete(rol);

            return RedirectToAction(nameof(Index));
        }
    }
}
