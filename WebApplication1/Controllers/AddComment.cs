using Microsoft.AspNetCore.Mvc;
using Dominio;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Extensions.Hosting;

namespace WebApplication1.Controllers
{
    public class AddComment : Controller
    {
        public IActionResult Comment(int postId)
        {
            Post post = (Post)Sistema.Instancia.GetPublicacionById(postId);
            return View("AddComment",post);
        }

       [HttpPost]
       public IActionResult Comment(int postId, string comment, string commentTitle)
       {

            try
            {
                int idMiembroLogueado = Sistema.Instancia.GetMiembroByEmail(HttpContext.Session.GetString("usuario")).Id;
                Sistema.Instancia.AgregarComentarioPost(postId, idMiembroLogueado, commentTitle, comment);
                ViewBag.MensajeExito = "Comentario creado con exito";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                Post post = (Post)Sistema.Instancia.GetPublicacionById(postId);
                return View("AddComment", post);
            }
        }
    }
}
