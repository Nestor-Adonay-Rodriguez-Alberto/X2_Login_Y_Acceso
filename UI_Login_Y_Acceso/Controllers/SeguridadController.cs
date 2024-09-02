using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Logica_Negocio;
using Entidades;

namespace P2_Login_Y_Acceso.Controllers
{
    [Authorize]
    public class SeguridadController : Controller
    {
        // Representa La DB:
        private readonly SeguridadBL _SeguridadBL;


        // Constructor:
        public SeguridadController(SeguridadBL seguridadBL)
        {
            _SeguridadBL = seguridadBL;
        }


        // Me Manda A La Vista
        [AllowAnonymous]
        public async Task<IActionResult> Login(string ReturnUrl)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }



        //Recibe un Objeto y Busca Otro Que Tenga Los Mismos Datos En La DB:
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login( Profesor profesor, string ReturnUrl)
        {
            //Encriptamos Primero:
            profesor.Password = EncriptarMD5(profesor.Password);


            //Buscamos En La DB:
            var Objeto_Obtenido = await _SeguridadBL.Creadenciales_Profesor(profesor);

            if (Objeto_Obtenido != null)
            {
                var claims = new[] {
                    new Claim(ClaimTypes.Name, Objeto_Obtenido.Nombre),
                    new Claim(ClaimTypes.Role, Objeto_Obtenido.Objeto_Rol.Nombre),
                    new Claim("IdProfesor", Objeto_Obtenido.IdProfesor.ToString())
                    };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties { IsPersistent = true }); ;

                var result = User.Identity.IsAuthenticated;

                if (!string.IsNullOrWhiteSpace(ReturnUrl))
                    return Redirect(ReturnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Credenciales Incorrectas.";
            }

            ViewBag.pReturnUrl = ReturnUrl;

            return View(Objeto_Obtenido);
        }



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
