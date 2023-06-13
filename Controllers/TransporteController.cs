using DreamyReefs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace DreamyReefs.Controllers
{
    public class TransporteController : Controller
    {
        private readonly ILogger<TransporteController> _logger;

        public TransporteController(ILogger<TransporteController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
