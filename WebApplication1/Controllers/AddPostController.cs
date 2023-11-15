using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AddPostController : Controller
    {

        public IActionResult AddPost(string mensaje)
        {
            ViewBag.MensajeExito = mensaje;
            return View("AddPost");
        }

        [HttpPost]
        public IActionResult AddPost(string Titulo, string Image, string Texto, bool Publico)
        {
            Miembro miembroLogeado = Sistema.Instancia.GetMiembroByEmail(HttpContext.Session.GetString("usuario"));
            try
            {
                Sistema.Instancia.AgregarPostMiembro(miembroLogeado.Id, Titulo, Texto, Image, Publico);
                return RedirectToAction("Index", "Home", new { mensajeExito = "Post creado con exito" });
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }

        }
    }
}
