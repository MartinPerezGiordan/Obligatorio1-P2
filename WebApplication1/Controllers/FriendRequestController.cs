using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class FriendRequestController : Controller
    {
        public IActionResult FriendRequest()
        {

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Login", "Login", new { mensaje = "no tienes acceso" });
            }

            Miembro miembroLogeado = Sistema.Instancia.GetMiembroByEmail(HttpContext.Session.GetString("usuario"));
            List<Miembro> invitacionesPendientes = miembroLogeado.ObtenerInvitacionesPendientesRecibidas();

            return View("FriendRequest", invitacionesPendientes);
        }

    }
}
