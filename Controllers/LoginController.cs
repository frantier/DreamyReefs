using DreamyReefs.Data;
using DreamyReefs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DreamyReefs.Controllers
{
    public class LoginController : Controller
    {
        private readonly Conexion _conexion;

        public LoginController(Conexion con)
        {
            _conexion = con;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccesoWeb accesoWeb)
        {
            if (accesoWeb.Correo is not null && accesoWeb.Contrasena is not null)
            {
                _conexion.InicioSesion(accesoWeb.Correo, accesoWeb.Contrasena);
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }
    }
}