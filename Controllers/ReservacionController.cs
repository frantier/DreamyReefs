using DreamyReefs.Data;
using DreamyReefs.Models;
using DreamyReefs.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using System.Diagnostics;


namespace DreamyReefs.Controllers
{
    public class ReservacionController : Controller
    {
        private readonly Conexion _conexion;

            public ReservacionController(Conexion con)
            {
                _conexion = con;
            }

            public IActionResult Index()
            {
                var reservaciones = _conexion.GetAllReservaciones().ToList();
                return View(reservaciones);
            }

            public IActionResult Crear()
            {
                return View();
            }

            public IActionResult Actualizar(int id)
            {
                var reservacion = _conexion.GetOneReservaciones(id);
                return View(reservacion);
            }

            [HttpPost]
            public IActionResult Actualizar(Reservacion reservacion)
            {
                if (ModelState.IsValid && reservacion.IDReservaciones > 0 && reservacion.NombreCompleto is not null && reservacion.Telefono is not null && reservacion.Email is not null && reservacion.Adultos > 0 && reservacion.Infantes > 0 && reservacion.Estatus is not null)
                {
                    _conexion.ActualizarReservaciones(reservacion.IDReservaciones, reservacion.NombreCompleto, reservacion.Telefono, reservacion.Email, reservacion.Adultos, reservacion.Infantes, reservacion.Estatus);
                    return RedirectToAction("Index");
                }
                return View();
            }

            public IActionResult Eliminar(int id)
            {
                var reservacion = _conexion.GetOneReservaciones(id);
                return View(reservacion);
            }


            [HttpPost]
            public IActionResult Eliminar(Reservacion reservacion)
            {
                if (reservacion.IDReservaciones > 0)
                {
                    _conexion.EliminarReservaciones(reservacion.IDReservaciones);
                    return RedirectToAction("Index");
                }
                return View();
            }

        
    }
}
