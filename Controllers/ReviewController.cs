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
            var review = _conexion.GetAllReviews().ToList();
            return View(review);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Review review)
        {
            if (ModelState.IsValid && review.TourID > 0 && review.Comentario is not null)
            {
                _conexion.CrearReviews(review.TourID, review.Comentario);
                return RedirectToAction("Index");
            }
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
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Eliminar(int id)
        {
            var review = _conexion.GetOneReviews(id);
            return View(review);
        }


        [HttpPost]
        public IActionResult Eliminar(Review review)
        {
            if (review.IDReviews > 0)
            {
                _conexion.EliminarReviews(review.IDReviews);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
