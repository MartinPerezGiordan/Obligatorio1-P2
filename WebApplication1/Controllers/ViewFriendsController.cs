using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ViewFriendsController : Controller
    {
        public IActionResult ViewFriends()
        {

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Login", "Login", new { mensaje = "no tienes acceso" });
            }

            Miembro miembroLogeado = Sistema.Instancia.GetMiembroByEmail(HttpContext.Session.GetString("usuario"));
            List<Miembro> Amigos = miembroLogeado.GetListaDeAmigos();
            return View("ViewFriends", Amigos);
        }
    }
}
