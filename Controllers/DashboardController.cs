using DreamyReefs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DreamyReefs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using DreamyReefs.Data;

namespace DreamyReefs.Controllers
{
    public class DashboardController : Controller
    {
        private readonly Conexion _conexion;

        public DashboardController(Conexion con)
        {
            _conexion = con;
        }

        public IActionResult Index()
        {

            var usuario = HttpContext.Session.GetString("Usuario");
            var storedToken = HttpContext.Session.GetString("Token");

            var Tok = new DashboardViewModel
            {
                Token = storedToken
            };
            if (Tok.Token != null && Tok.Token == storedToken)
            {
                var model = new DashboardViewModel
                {
                    Usuario = usuario
                    //Token = token
                };

                Graficas();

                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }

        public IActionResult Salir()
        {
            // Eliminar los datos de la sesión del usuario
            HttpContext.Session.Remove("Usuario");
            HttpContext.Session.Remove("Token");

            HttpContext.Session.Clear();

            // Eliminar la cookie del token si existe
            if (Request.Cookies.ContainsKey("Token"))
            {
                Response.Cookies.Delete("Token");
            }

            // Redirigir al login
            return RedirectToAction("Login", "Login");
        }

        public IActionResult Graficas()
        {
            var data = _conexion.GetGraficas();
            ViewBag.ChartData = data;

            return View();
        }

    }
}
    