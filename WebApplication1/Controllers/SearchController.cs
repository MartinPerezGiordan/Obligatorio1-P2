using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class SearchController : Controller
    {
        
        public IActionResult Search()
        {
            List<Publicacion> publicaciones = Sistema.Instancia.GetPublicaciones();
            ViewBag.Mensaje = "Todas las publicaciones";
            return View("Search", publicaciones);
        }

        [HttpPost]
        public IActionResult SearchPublicacion(string textoBuscado, double va)
        {
            List<Publicacion> publicacionesBuscadas = Sistema.Instancia.BuscarPublicacionPorString(textoBuscado, va);
            ViewBag.Mensaje = "Publicaciones que contienen el texto: " + textoBuscado + " y valor de aceptacion mayor a " + va;
            return View("Search", publicacionesBuscadas);
        }

    }
}
