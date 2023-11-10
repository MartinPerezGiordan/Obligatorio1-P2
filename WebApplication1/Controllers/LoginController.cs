using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View();
        }

        [HttpPost]

        public IActionResult Login(string email, string password)
        {
            if (Sistema.Instancia.ValidarLogin(email, password))
            {
                HttpContext.Session.SetString("usuario", email);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", new { mensaje = "Nombre de usuario o contraseña incorrecta." });
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("usuario", "");
            return RedirectToAction("Login");
        }
    }
}
