using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace WebApplication1.Controllers
{
    public class AddFriendController : Controller
    {




        public IActionResult AddFriend()
        {

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Login", "Login", new { mensaje = "no tienes acceso" });
            }

            Miembro miembroLogeado = Sistema.Instancia.GetMiembroByEmail(HttpContext.Session.GetString("usuario"));
            List<Miembro> noAmigos = miembroLogeado.ObtenerNoAmigos();
            ViewBag.Pendientes = miembroLogeado.ObtenerInvitacionesPendientesEnviadas();
			return View("AddFriend", noAmigos);
		}

        [HttpPost]
        public IActionResult AgregarAmigo(int noAmigoId)
        {

            Miembro miembroLogeado = Sistema.Instancia.GetMiembroByEmail(HttpContext.Session.GetString("usuario"));
            Sistema.Instancia.EnviarInvitacion(miembroLogeado.Id, noAmigoId);
            ViewBag.Mensaje = "Se ha enviado la solicitud a " + Sistema.Instancia.GetMiembroById(noAmigoId).Nombre +" "+ Sistema.Instancia.GetMiembroById(noAmigoId).Apellido + " con exito.";
            List<Miembro> noAmigos = miembroLogeado.ObtenerNoAmigos();
            ViewBag.Pendientes = miembroLogeado.ObtenerInvitacionesPendientesEnviadas();
            return View("AddFriend", noAmigos);
        }
    }
}
