using Aduanas.Models;
using CustomUserLogin.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using Aduanas.Permisos;

namespace Aduanas.Controllers
{
    [Authentication]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult PermisoDenegado()
        {
            return View();
        }

        public ActionResult CloseSS()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Usuario");
            return RedirectToAction("index", "Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}