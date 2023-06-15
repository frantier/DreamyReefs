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
            var transportes = _conexion.GetAllTransportes().ToList();
            return View(transportes);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Transporte transporte)
        {
            if (ModelState.IsValid && transporte.NombreEmpresa is not null && transporte.transporte is not null)
            {
                _conexion.CrearTransportes(transporte.NombreEmpresa, transporte.transporte);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Actualizar(int id)
        {
            var transporte = _conexion.GetOneTransportes(id);
            return View(transporte);
        }

        [HttpPost]
        public IActionResult Actualizar(Transporte transporte)
        {
            if (ModelState.IsValid && transporte.IDTransportes > 0 && transporte.NombreEmpresa is not null && transporte.transporte is not null)
            {
                _conexion.ActualizarTransportes(transporte.IDTransportes, transporte.NombreEmpresa, transporte.transporte);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Eliminar(int id)
        {
            var transporte = _conexion.GetOneTransportes(id);
            return View(transporte);
        }


        [HttpPost]
        public IActionResult Eliminar(Transporte transporte)
        {
            if (transporte.IDTransportes > 0)
            {
                _conexion.EliminarTransportes(transporte.IDTransportes);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
