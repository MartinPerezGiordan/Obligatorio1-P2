using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ListMembersController : Controller
    {

        public IActionResult ListMembers()
        {

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Login", "Login", new { mensaje = "no tienes acceso" });
            }

            List<Miembro> miembros = Sistema.Instancia.GetMiembros();
            miembros.Sort();
            return View("ListMembers", miembros);
        }

        [HttpPost]
        public IActionResult Block(int unMiembroId)
        {
            Miembro miembroBloqueado = Sistema.Instancia.GetMiembroId(unMiembroId);
            Sistema.Instancia.BloquearMiembro(unMiembroId, true);
            ViewBag.Mensaje = "Se ha bloqueado al miembro con ID " + miembroBloqueado.Id + " " + miembroBloqueado.Nombre + " " + miembroBloqueado.Apellido;
            List<Miembro> miembrosActualizados = Sistema.Instancia.GetMiembros();
            miembrosActualizados.Sort();
            return View("ListMembers", miembrosActualizados);
        }
        [HttpPost]
        public IActionResult UnBlock(int unMiembroId)
        {
            Miembro miembroBloqueado = Sistema.Instancia.GetMiembroId(unMiembroId);
            Sistema.Instancia.BloquearMiembro(unMiembroId, false);
            ViewBag.Mensaje = "Se ha desbloqueado al miembro con ID " + miembroBloqueado.Id + " " + miembroBloqueado.Nombre + " " + miembroBloqueado.Apellido;
            List<Miembro> miembrosActualizados = Sistema.Instancia.GetMiembros();
            miembrosActualizados.Sort();
            return View("ListMembers", miembrosActualizados);
        }
    }
}
