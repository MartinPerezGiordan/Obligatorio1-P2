using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class SearchController : Controller
    {
        
        public IActionResult Search()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Login", "Login", new { mensaje = "no tienes acceso" });
            }

            Miembro miembroLogeado = Sistema.Instancia.GetMiembroByEmail(HttpContext.Session.GetString("usuario"));

            List<Publicacion> publicaciones = Sistema.Instancia.GetPublicaciones();
            List<Publicacion> publicacionesAMostrar = new List<Publicacion>();
            List<Publicacion> publicacionesComentarios= new List<Publicacion>();
            if (miembroLogeado is Miembro)
            {
                foreach (Publicacion publicacion in publicaciones)
                {
                    if (publicacion is Post)
                    {
                        Post post = publicacion as Post;
                        if (post.Censurado == false)
                        {
                            if (post.Publico)
                            {
                                publicacionesAMostrar.Add(post);
                                publicacionesComentarios.Add(post);
                            }
                            else if (post.Autor == miembroLogeado)
                            {
                                publicacionesAMostrar.Add(post);
                                publicacionesComentarios.Add(post);
                            }
                            if (miembroLogeado.GetListaDeAmigos() != null)
                            {
                                foreach (Miembro amigo in miembroLogeado.GetListaDeAmigos())
                                {
                                    if (amigo == post.Autor)
                                    {
                                        publicacionesAMostrar.Add(post);

                                    }
                                }
                            }
                        }
                    }

                }
            }
            foreach(Post unPost in publicacionesAMostrar)
            {
                foreach(Comentario unComentario in unPost.GetComentarios())
                {
                    publicacionesComentarios.Add(unComentario);
                }
            }
            ViewBag.Mensaje = "Todas las publicaciones";
            return View("Search", publicacionesComentarios);
        }

        [HttpPost]
        public IActionResult SearchPublicacion(string textoBuscado, double va)
        {
            Miembro miembroLogeado = Sistema.Instancia.GetMiembroByEmail(HttpContext.Session.GetString("usuario"));

            List<Publicacion> publicaciones = Sistema.Instancia.GetPublicaciones();
            List<Publicacion> publicacionesAMostrar = new List<Publicacion>();
            List<Publicacion> publicacionesComentarios = new List<Publicacion>();
            if (miembroLogeado is Miembro)
            {
                foreach (Publicacion publicacion in publicaciones)
                {
                    if (publicacion is Post)
                    {
                        Post post = publicacion as Post;
                        if (post.Censurado == false)
                        {
                            if (post.Publico)
                            {
                                publicacionesAMostrar.Add(post);
                                publicacionesComentarios.Add(post);
                            }
                            else if (post.Autor == miembroLogeado)
                            {
                                publicacionesAMostrar.Add(post);
                                publicacionesComentarios.Add(post);
                            }
                            if (miembroLogeado.GetListaDeAmigos() != null)
                            {
                                foreach (Miembro amigo in miembroLogeado.GetListaDeAmigos())
                                {
                                    if (amigo == post.Autor)
                                    {
                                        publicacionesAMostrar.Add(post);

                                    }
                                }
                            }
                        }
                    }

                }
            }
            foreach (Post unPost in publicacionesAMostrar)
            {
                foreach (Comentario unComentario in unPost.GetComentarios())
                {
                    publicacionesComentarios.Add(unComentario);
                }
            }
            List<Publicacion> publicacionesBuscadas = Sistema.Instancia.BuscarPublicacionPorString(publicacionesComentarios,textoBuscado, va);
            ViewBag.Mensaje = "Publicaciones que contienen el texto: " + textoBuscado + " y valor de aceptacion mayor a " + va;
            return View("Search", publicacionesBuscadas);
        }

    }
}
