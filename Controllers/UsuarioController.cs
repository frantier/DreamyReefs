using DreamyReefs.Data;
using DreamyReefs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace DreamyReefs.Controllers
{
    
    public class UsuarioController : Controller
    {
        private readonly Conexion _conexion;

        public UsuarioController(Conexion con)
        {
            _conexion = con;
        }

        public IActionResult Index()
        {
            var accesosweb = _conexion.GetAllUsuarios().ToList();
            return View(accesosweb);
        }

        public IActionResult Crear()
        {
            var storedToken = HttpContext.Session.GetString("Token");
            
            var model = new DashboardViewModel
            {
                Token = storedToken
            };
            if (model.Token != null && model.Token == storedToken)
            {
               return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            
        }

        [HttpPost]
        public IActionResult Crear(AccesoWeb accesoWeb)
        {
            if (ModelState.IsValid && accesoWeb.Nombre is not null && accesoWeb.Usuario is not null && accesoWeb.Correo is not null && accesoWeb.Contrasena is not null && accesoWeb.Estatus is not null)
            {
                _conexion.CrearUsuario(accesoWeb.Usuario, accesoWeb.Nombre, accesoWeb.Correo, accesoWeb.Contrasena, accesoWeb.Estatus);
                TempData["SuccessMessage"] = "El usuario se ha creado exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Actualizar(int id)
        {
            var storedToken = HttpContext.Session.GetString("Token");            
            var model = new DashboardViewModel
            {
                Token = storedToken
            };
            if (model.Token != null && model.Token == storedToken)
            {
               var usuario = _conexion.GetOneUsuario(id);
                return View(usuario);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            
        }

        [HttpPost]
        public IActionResult Actualizar(AccesoWeb accesoWeb)
        {
            if (ModelState.IsValid && accesoWeb.Nombre is not null && accesoWeb.Usuario is not null && accesoWeb.Correo is not null && accesoWeb.Contrasena is not null && accesoWeb.Estatus is not null && accesoWeb.IDAccesoWeb > 0)
            {
                _conexion.ActualizarUsuario(accesoWeb.IDAccesoWeb, accesoWeb.Usuario, accesoWeb.Nombre, accesoWeb.Correo, accesoWeb.Contrasena, accesoWeb.Estatus);
                TempData["SuccessMessage"] = "El usuario se ha actualizado exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }

        //public IActionResult Eliminar(int id)
        //{
        //    var storedToken = HttpContext.Session.GetString("Token");            
        //    var model = new DashboardViewModel
        //    {
        //        Token = storedToken
        //    };
        //    if (model.Token != null && model.Token == storedToken)
        //    {
        //       var usuario = _conexion.GetOneUsuario(id);
        //        return View(usuario);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login", "Login");
        //    }
            
        //}


        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            if (id > 0)
            {
                _conexion.EliminarUsuario(id);
                return Ok(); // Devuelve una respuesta exitosa al AJAX
            }

            return BadRequest(); // Otra respuesta de error si el id no es válido
        }

    }
}