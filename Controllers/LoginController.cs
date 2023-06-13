using DreamyReefs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DreamyReefs.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}