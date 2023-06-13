using DreamyReefs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace DreamyReefs.Controllers
{
    public class TourController : Controller
    {
        private readonly ILogger<TourController> _logger;

        public TourController(ILogger<TourController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detalle()
        {
            return View();
        }
    }
}
