using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Login", "Login", new { mensaje = "no tienes acceso" });
            }


            Miembro miembroLogeado = Sistema.Instancia.GetMiembroByEmail(HttpContext.Session.GetString("usuario"));
            ViewBag.Nombre = miembroLogeado.Nombre + " " + miembroLogeado.Apellido;
            ViewBag.IdUsuario = miembroLogeado.Id;
            List<Publicacion> publicaciones = Sistema.Instancia.GetPublicaciones();
            List<Post> postsAMostrar = new List<Post>();

            foreach (Publicacion publicacion in publicaciones)
            {
                if (publicacion is Post)
                {
                    Post post = publicacion as Post;
                    if (post.Publico)
                    {
                        postsAMostrar.Add(post);
                    }
                    else if (post.Autor == miembroLogeado)
                    {
                        postsAMostrar.Add(post);
                    }
                    List<Miembro> amigos = miembroLogeado.GetListaDeAmigos();
                    if (amigos == null)
                    {
                        amigos = new List<Miembro>();
                    }
                    foreach (Miembro amigo in amigos)
                    {
                        if (amigo == post.Autor)
                        {
                            postsAMostrar.Add(post);
                        }
                    }
                }

            }
            ViewBag.Posts = postsAMostrar;
            return View();
        }

        public IActionResult LikePost(bool like, int postId)
        {
            int idUsuario = Sistema.Instancia.GetMiembroByEmail(HttpContext.Session.GetString("usuario")).Id;
            Sistema.Instancia.LikearUnaPublicacion(idUsuario, postId, like);


            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult LikeComentario(bool like, int comentarioId)
        {
            int idUsuario = Sistema.Instancia.GetMiembroByEmail(HttpContext.Session.GetString("usuario")).Id;
            Sistema.Instancia.LikearUnaPublicacion(idUsuario, comentarioId, like);


            return RedirectToAction("Index", "Home");
        }
    }
}
