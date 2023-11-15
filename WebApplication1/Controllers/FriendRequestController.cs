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
            List<Miembro> invitacionesPendientes = miembroLogeado.ObtenerMiembrosConInvitacionesPendientesRecibidas();

            return View("FriendRequest", invitacionesPendientes);
        }

        [HttpPost]
        public IActionResult Aceptar(int pendienteId)
        {
            Miembro miembroLogeado = Sistema.Instancia.GetMiembroByEmail(HttpContext.Session.GetString("usuario"));

            foreach(Invitacion unaInvitacion in Sistema.Instancia.GetInvitaciones())
            {
                if(unaInvitacion.GetIdMiembroSolicitante() == pendienteId && unaInvitacion.GetIdMiembroSolicitado() == miembroLogeado.Id)
                {
                    Sistema.Instancia.AceptarInvitacion(unaInvitacion);
                }
            }
            List<Miembro> invitacionesPendientes = miembroLogeado.ObtenerMiembrosConInvitacionesPendientesRecibidas();


            return View("FriendRequest", invitacionesPendientes);
        }

    }
}
