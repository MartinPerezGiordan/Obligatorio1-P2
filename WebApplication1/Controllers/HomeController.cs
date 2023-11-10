using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Login", "Login", new { mensaje = "no tienes acceso" });
            }

            ViewBag.nombre = "Pedro Paez";
            return View();
        }
    }
}
