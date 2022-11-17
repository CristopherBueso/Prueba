using Microsoft.AspNetCore.Mvc;

using Aduanas.Models;
using Aduanas.Logica;
using Newtonsoft.Json;

namespace Aduanas.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login()
        {
            if(HttpContext.Session.GetString("Usuario") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        [HttpPost]
        public ActionResult Index(string usuario, string clave)
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                Usuarios obj = new LO_Usuario().EncontrarUsuario(usuario, clave);

                if (obj != null)
                {
                    HttpContext.Session.SetString("Usuario", JsonConvert.SerializeObject(obj));

                    return RedirectToAction("index", "Home");
                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
            }
            return View();
        }
    }
}
