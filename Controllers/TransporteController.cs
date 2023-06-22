using DreamyReefs.Data;
using DreamyReefs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace DreamyReefs.Controllers
{
    public class TransporteController : Controller
    {
        private readonly Conexion _conexion;

        public TransporteController(Conexion con)
        {
            _conexion = con;
        }

        public IActionResult Index()
        {
            var storedToken = HttpContext.Session.GetString("Token");            
            var model = new DashboardViewModel
            {
                Token = storedToken
            };
            if (model.Token != null && model.Token == storedToken)
            {
               var transportes = _conexion.GetAllTransportes().ToList();
                return View(transportes);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            
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
        public IActionResult Crear(Transportes transportes)
        {
            if (ModelState.IsValid && transportes.NombreEmpresa is not null && transportes.Transporte is not null)
            {
                _conexion.CrearTransportes(transportes.NombreEmpresa, transportes.Transporte);
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
                var transporte = _conexion.GetOneTransportes(id);
                return View(transporte);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            
        }

        [HttpPost]
        public IActionResult Actualizar(Transportes transportes)
        {
            if (ModelState.IsValid && transportes.IDTransportes > 0 && transportes.NombreEmpresa is not null && transportes.Transporte is not null)
            {
                _conexion.ActualizarTransportes(transportes.IDTransportes, transportes.NombreEmpresa, transportes.Transporte);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Eliminar(int id)
        {
            var storedToken = HttpContext.Session.GetString("Token");            
            var model = new DashboardViewModel
            {
                Token = storedToken
            };
            if (model.Token != null && model.Token == storedToken)
            {
                var transporte = _conexion.GetOneTransportes(id);
                return View(transporte);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            
        }


        [HttpPost]
        public IActionResult Eliminar(Transportes transportes)
        {
            if (transportes.IDTransportes > 0)
            {
                _conexion.EliminarTransportes(transportes.IDTransportes);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
