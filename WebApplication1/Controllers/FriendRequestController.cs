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
                    try
                    {
                        Sistema.Instancia.AceptarInvitacion(unaInvitacion);
                    }catch(Exception ex)
                    {
                        ViewBag.MensajeError = ex.Message;
                    }
                }
            }
            List<Miembro> invitacionesPendientes = miembroLogeado.ObtenerMiembrosConInvitacionesPendientesRecibidas();


            return View("FriendRequest", invitacionesPendientes);
        }

    }
}
