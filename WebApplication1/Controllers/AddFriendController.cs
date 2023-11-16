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

            Miembro miembroLogueado = Sistema.Instancia.GetMiembroByEmail(HttpContext.Session.GetString("usuario"));
            ViewBag.Pendientes = miembroLogueado.ObtenerMiembrosConInvitacionesPendientes();
            List<Miembro> noAmigos = miembroLogueado.ObtenerNoAmigos();
			return View("AddFriend", noAmigos);
		}

        [HttpPost]
        public IActionResult AddFriend(int noAmigoId)
        {

            Miembro miembroLogueado = Sistema.Instancia.GetMiembroByEmail(HttpContext.Session.GetString("usuario"));
            Sistema.Instancia.EnviarInvitacion(miembroLogueado.Id, noAmigoId);
            ViewBag.Mensaje = "Se ha enviado la solicitud a " + Sistema.Instancia.GetMiembroById(noAmigoId).Nombre +" "+ Sistema.Instancia.GetMiembroById(noAmigoId).Apellido + " con exito.";
            List<Miembro> noAmigos = miembroLogueado.ObtenerNoAmigos();
            ViewBag.Pendientes = miembroLogueado.ObtenerMiembrosConInvitacionesPendientes();
            return View("AddFriend", noAmigos);
        }
    }
}
