using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace WebApplication1.Controllers
{
    public class AddFriendController : Controller
    {
        private List<Miembro> ObtenerNoAmigos()
        {
            Miembro miembroLogeado = Sistema.Instancia.GetMiembroByEmail(HttpContext.Session.GetString("usuario"));
            List<Miembro> noAmigos = new List<Miembro>();  
            
            foreach(Miembro unMiembro in Sistema.Instancia.GetMiembros() )
            {
                if (!miembroLogeado.esAmigoById(unMiembro.Id))
                {

                    bool estaPendiente = false;

                    foreach(Invitacion invitacion in miembroLogeado.GetInvitacionesEnviadas())
                    {
                        if(invitacion.GetIdMiembroSolicitado() == unMiembro.Id) {
                        estaPendiente = true;    
                    }
                    }
                    if (!estaPendiente)
                    {
                        noAmigos.Add(unMiembro);
                    }
                }
            }
            return noAmigos;
        }

        private List<Miembro> ObtenerPendientes()
        {
            Miembro miembroLogeado = Sistema.Instancia.GetMiembroByEmail(HttpContext.Session.GetString("usuario"));
            List<Miembro> pendientes = new List<Miembro>();

            foreach (Miembro unMiembro in Sistema.Instancia.GetMiembros())
            { 
                foreach (Invitacion invitacion in miembroLogeado.GetInvitacionesEnviadas())
                {
                    if (invitacion.GetIdMiembroSolicitado() == unMiembro.Id)
                    {
                        pendientes.Add(unMiembro) ;
                    }
                }
            }
            return pendientes;
        }

        public IActionResult AddFriend()
        {

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Login", "Login", new { mensaje = "no tienes acceso" });
            }

            List<Miembro> noAmigos = ObtenerNoAmigos();
            ViewBag.Pendientes = ObtenerPendientes();
			return View("AddFriend", noAmigos);
		}

        [HttpPost]
        public IActionResult AgregarAmigo(int noAmigoId)
        {
            
            List<Miembro> noAmigos = ObtenerNoAmigos();
            Miembro miembroLogeado = Sistema.Instancia.GetMiembroByEmail(HttpContext.Session.GetString("usuario"));

            Sistema.Instancia.EnviarInvitacion(miembroLogeado.Id, noAmigoId);
            ViewBag.Mensaje = "Se ha enviado la solicitud a " + Sistema.Instancia.GetMiembroById(noAmigoId).Nombre +" "+ Sistema.Instancia.GetMiembroById(noAmigoId).Apellido + " con exito.";
            ViewBag.Pendientes = ObtenerPendientes();
            return View("AddFriend", noAmigos);
        }
    }
}
