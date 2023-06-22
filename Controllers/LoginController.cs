using DreamyReefs.Data;
using DreamyReefs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            if (ModelState.IsValid)
            {
                var user = _conexion.InicioSesion(accesoWeb.Correo, accesoWeb.Contrasena);                
                if (user != null)
                {                    
                    HttpContext.Session.SetString("Usuario", user.Nombre);
                    HttpContext.Session.SetString("Token", user.RefreshToken);                    
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    // Usuario no existe o contraseña incorrecta
                    var usuarioExistente = _conexion.ValidarUsuario(accesoWeb.Correo);

                    if (usuarioExistente)
                    {
                        // Contraseña incorrecta
                        ViewBag.Error = "Contraseña incorrecta.";
                    }
                    else
                    {
                        ViewBag.Error = "Usuario incorrecto.";
                    }
                }
            }
            return View();
        }
    }
}
