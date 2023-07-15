using DreamyReefs.Data;
using Microsoft.AspNetCore.Mvc;

namespace DreamyReefs.Controllers
{
    public class AcercadeController : Controller
    {
        private readonly Conexion _conexion;

        public AcercadeController(Conexion con)
        {
            _conexion = con;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
