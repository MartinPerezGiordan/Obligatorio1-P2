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


            //Puede ver: SUYOS -- PUBLICOS -- AMIGOS

            List<Publicacion> publicaciones = Sistema.Instancia.GetPublicaciones();

            ViewBag.Nombre = HttpContext.Session.GetString("usuario");
            ViewBag.Publicaciones = publicaciones;
            return View();
        }
    }
}
