using Entidades;
using Logica_Negocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI_Login_Y_Acceso.Controllers
{
    [Authorize(Roles = "Director., Sub Director.")]
    public class CiudadController : Controller
    {
        // Puente Para La DB:
        private readonly CiudadBL _CiudadBL;

        // Constuctor:
        public CiudadController(CiudadBL ciudadBL)
        {
            _CiudadBL = ciudadBL;
        }


        // Manda Todos Los Objetos De La Tabla:
        public async Task<ActionResult> Index()
        {
            var Objetos_Obtenidos = await _CiudadBL.Obtener_Todos();

            return View(Objetos_Obtenidos);
        }

        // Manda Un Objeto De La Tabla:
        public async Task<ActionResult> Details(int id)
        {
            var Objeto_Obtenido = await _CiudadBL.Obtener_PorId(new Ciudad() { IdCiudad = id });

            return View(Objeto_Obtenido);
        }

        public ActionResult Create()
        {
            return View();
        }


        // Guarda El Objeto Del Parametro:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Ciudad ciudad)
        {
            await _CiudadBL.Create(ciudad);

            return RedirectToAction(nameof(Index));
        }


        // Manda Un Objeto De La Tabla:
        public async Task<ActionResult> Edit(int id)
        {
            var Objeto_Obtenido = await _CiudadBL.Obtener_PorId(new Ciudad() { IdCiudad = id });

            return View(Objeto_Obtenido);
        }


        // Manda El Objeto Y Lo Modifica:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Ciudad ciudad)
        {
            await _CiudadBL.Edit(ciudad);

            return RedirectToAction(nameof(Index));
        }


        // Manda El Objeto A VIsta
        public async Task<ActionResult> Delete(int id)
        {
            var Objeto_Obtenido = await _CiudadBL.Obtener_PorId(new Ciudad() { IdCiudad = id });

            return View(Objeto_Obtenido);
        }


        // Manda El Objeto Y Lo Elimina
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Ciudad ciudad)
        {
            await _CiudadBL.Delete(ciudad);

            return RedirectToAction(nameof(Index));
        }
    }
}
