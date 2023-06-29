using DreamyReefs.Data;
using DreamyReefs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace DreamyReefs.Controllers
{
    public class ReviewController : Controller
    {        
        private readonly Conexion _conexion;

        public ReviewController(Conexion con)
        {
            _conexion = con;
        }

        public IActionResult Index()
        {
            var reviews = _conexion.GetAllReviews().ToList();
            ViewBag.Tours = new Dictionary<int, string>();

            foreach (var review in reviews)
            {
                var tourID = review.TourID;
                var tour = _conexion.GetOneTour(tourID);
                ViewBag.Tours[tourID] = tour.Nombre;
            }

            return View(reviews);
        }

        public IActionResult Index2()
        {
            var reviews = _conexion.GetAllReviews().ToList();
            ViewBag.Tours = new Dictionary<int, string>();

            foreach (var review in reviews)
            {
                var tourID = review.TourID;
                var tour = _conexion.GetOneTour(tourID);
                ViewBag.Tours[tourID] = tour.Nombre;
            }

            return View(reviews);
        }

        public IActionResult Crear()
        {
            return View();
        }


        public IActionResult Actualizar(int id)
        {
            var usuario = _conexion.GetOneReviews(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Actualizar(Review review)
        {
            if (ModelState.IsValid && review.IDReviews > 0 && review.TourID > 0 && review.Comentario is not null)
            {
                _conexion.ActualizarReviews(review.IDReviews, review.TourID, review.Comentario);
                TempData["SuccessMessage"] = "Opinion actualizada exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }

        //public IActionResult Eliminar(int id)
        //{
        //    var review = _conexion.GetOneReviews(id);
        //    return View(review);
        //}


        //[HttpPost]
        //public IActionResult Eliminar(Review review)
        //{
        //    if (review.IDReviews > 0)
        //    {
        //        _conexion.EliminarReviews(review.IDReviews);
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            if (id > 0)
            {
                _conexion.EliminarReviews(id);
                return Ok(); // Devuelve una respuesta exitosa al AJAX
            }

            return BadRequest(); // Otra respuesta de error si el id no es válido
        }
    }
}

