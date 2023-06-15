using DreamyReefs.Data;
using DreamyReefs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DreamyReefs.Controllers
{
    public class LoginController : Controller
    {
        private readonly Conexion _conexion;

        public LoginController(Conexion con)
        {
            _conexion = con;
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}