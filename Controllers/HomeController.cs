using DreamyReefs.Data;
using DreamyReefs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DreamyReefs.Controllers
{
    public class HomeController : Controller
    {
        private readonly Conexion _conexion;

        public HomeController(Conexion con)
        {
            _conexion = con;
        }

        public IActionResult Index()
        {

            var reviews = _conexion.GetAllReviews().ToList();
            ViewBag.Imagen = new Dictionary<int, string>();
            
            foreach (var review in reviews)
            {
                var imagenID = review.TourID;
                var img = _conexion.GetOneImagenesTour(imagenID);
                ViewBag.Imagen[imagenID] = img.ImagenBase64;
            }

            ViewBag.Tours = new Dictionary<int, string>();

            foreach (var review in reviews)
            {
                var tourID = review.TourID;
                var tour = _conexion.GetOneTour(tourID);
                ViewBag.Tours[tourID] = tour.Nombre;
            }

            return View(reviews);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}