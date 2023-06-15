using DreamyReefs.Data;
using DreamyReefs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace DreamyReefs.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly Conexion _conexion;

        public EmpresaController(Conexion con)
        {
            _conexion = con;
        }

        public IActionResult Index()
        {
            var empresa = _conexion.GetAllEmpresas().ToList();
            return View(empresa);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Empresa empresa)
        {
            if (ModelState.IsValid && empresa.NombreEmpresa is not null && empresa.Correo is not null && empresa.Telefono is not null && empresa.Direccion is not null && empresa.RFC is not null)
            {
                _conexion.CrearEmpresas(empresa.NombreEmpresa, empresa.Correo, empresa.Telefono, empresa.Direccion, empresa.RFC);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Actualizar(int id)
        {
            var empresa = _conexion.GetOneEmpresas(id);
            return View(empresa);
        }

        [HttpPost]
        public IActionResult Actualizar(Empresa empresa)
        {
            if (ModelState.IsValid && empresa.IDEmpresas > 0 && empresa.NombreEmpresa is not null && empresa.Correo is not null && empresa.Telefono is not null && empresa.Direccion is not null && empresa.RFC is not null)
            {
                _conexion.ActualizarEmpresas(empresa.IDEmpresas, empresa.NombreEmpresa, empresa.Correo, empresa.Telefono, empresa.Direccion, empresa.RFC);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Eliminar(int id)
        {
            var empresa = _conexion.GetOneEmpresas(id);
            return View(empresa);
        }


        [HttpPost]
        public IActionResult Eliminar(Empresa empresa)
        {
            if (empresa.IDEmpresas > 0)
            {
                _conexion.EliminarEmpresas(empresa.IDEmpresas);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
