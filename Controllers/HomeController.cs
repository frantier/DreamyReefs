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