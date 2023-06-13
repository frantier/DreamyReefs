using DreamyReefs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace DreamyReefs.Controllers
{
    public class ReservacionController : Controller
    {
        private readonly ILogger<ReservacionController> _logger;

        public ReservacionController(ILogger<ReservacionController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
