using DreamyReefs.Data;
using DreamyReefs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace DreamyReefs.Controllers
{
    public class TourController : Controller
    {

        private readonly Conexion _conexion;

        public TourController(Conexion con)
        {
            _conexion = con;
        }

        public IActionResult Index2()
        {
            var tours = _conexion.GetAllTours().ToList();
            return View(tours);
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
                var tours = _conexion.GetAllTours().ToList();
                return View(tours);
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
        public IActionResult Crear(Tours tours)
        {
            if (ModelState.IsValid && tours.Nombre is not null && tours.Itinerario is not null && tours.Precio > 0 && tours.Descripcion is not null && tours.Disponibilidad is not null && tours.Idioma is not null && tours.Categoria1 is not null && tours.Categoria2 is not null && tours.Categoria3 is not null && tours.Categoria4 is not null && tours.Caracteristica1 is not null && tours.Caracteristica2 is not null && tours.Caracteristica3 is not null && tours.Estatus is not null && tours.PrecioAdulto > 0 && tours.PrecioInfantes > 0)
            {
                _conexion.CrearTour(tours.Nombre, tours.Itinerario, tours.Precio, tours.Descripcion, tours.Disponibilidad, tours.Idioma, tours.Categoria1, tours.Categoria2, tours.Categoria3, tours.Categoria4, tours.Caracteristica1, tours.Caracteristica2, tours.Caracteristica3, tours.Estatus, tours.PrecioAdulto, tours.PrecioInfantes);
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
                var tours = _conexion.GetOneTour(id);
                return View(tours);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            
        }

        [HttpPost]
        public IActionResult Actualizar(Tours tours)
        {
            if (ModelState.IsValid && tours.Nombre is not null && tours.Itinerario is not null && tours.Precio > 0 && tours.Descripcion is not null && tours.Disponibilidad is not null && tours.Idioma is not null && tours.Categoria1 is not null && tours.Categoria2 is not null && tours.Categoria3 is not null && tours.Categoria4 is not null && tours.Caracteristica1 is not null && tours.Caracteristica2 is not null && tours.Caracteristica3 is not null && tours.Estatus is not null && tours.PrecioAdulto > 0 && tours.PrecioInfantes > 0)
            {
                _conexion.ActualizarTour(tours.IDTours, tours.Nombre, tours.Itinerario, tours.Precio, tours.Descripcion, tours.Disponibilidad, tours.Idioma, tours.Categoria1, tours.Categoria2, tours.Categoria3, tours.Categoria4, tours.Caracteristica1, tours.Caracteristica2, tours.Caracteristica3, tours.Estatus, tours.PrecioAdulto, tours.PrecioInfantes);
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
                var tours = _conexion.GetOneTour(id);
                return View(tours);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            
        }


        [HttpPost]
        public IActionResult Eliminar(Tours tours)
        {
            if (tours.IDTours > 0)
            {
                _conexion.EliminarTour(tours.IDTours);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Detalle(int id)
        {
            var tours = _conexion.GetOneTour(id);
            return View(tours);
        }


        // public IActionResult GetCategorias()
        // {
        //     // Obtener la lista de categorías desde la tabla correspondiente
        //     var listaCategorias = _conexion.GetAllCategorias(); // Reemplaza "_tuRepositorio.ObtenerListaCategorias()" con el método o la lógica adecuada para obtener la lista de categorías

        //     var model = new Tours();
        //     model.ListaCategorias = listaCategorias; // Agregar la lista de categorías al modelo

        //     return View(model);
        // }

    }
}
