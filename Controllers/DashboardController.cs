using DreamyReefs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DreamyReefs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace DreamyReefs.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(ILogger<DashboardController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            var usuario = HttpContext.Session.GetString("Usuario");

            var model = new DashboardViewModel
            {
                Usuario = usuario
            };

            return View(model);
        }

        public IActionResult Salir()
        {
            // Eliminar los datos de la sesión del usuario
            HttpContext.Session.Clear();

            // Redirigir al login
            return RedirectToAction("Login", "Login");
        }

    }
}
