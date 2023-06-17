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
            var transporte = _conexion.GetOneTransportes(id);
            return View(transporte);
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
            var transporte = _conexion.GetOneTransportes(id);
            return View(transporte);
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
