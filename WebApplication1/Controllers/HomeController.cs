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

            Administrador administradorLogeado = Sistema.Instancia.GetAdministradorByEmail(HttpContext.Session.GetString("usuario"));

            Miembro miembroLogeado = Sistema.Instancia.GetMiembroByEmail(HttpContext.Session.GetString("usuario"));

            if(miembroLogeado is Miembro)
            {
                ViewBag.Nombre = miembroLogeado.Nombre + " " + miembroLogeado.Apellido;
                ViewBag.IsAdmin = false;
            } else if(administradorLogeado is Administrador)
            {
                ViewBag.Nombre = administradorLogeado.Nombre + " " + administradorLogeado.Apellido;
                ViewBag.IsAdmin = true;
            }

            List<Publicacion> publicaciones = Sistema.Instancia.GetPublicaciones();
            List<Post> postsAMostrar = new List<Post>();
            if(miembroLogeado is Miembro)
            {
                foreach (Publicacion publicacion in publicaciones)
                {
                    if (publicacion is Post)
                    {
                        Post post = publicacion as Post;
                        if(post.Censurado == false)
                        {
                            if (post.Publico)
                            {
                                postsAMostrar.Add(post);
                            }
                            else if (post.Autor == miembroLogeado)
                            {
                                postsAMostrar.Add(post);
                            }
                            foreach (Miembro amigo in miembroLogeado.GetListaDeAmigos())
                            {
                                if (amigo == post.Autor)
                                {
                                    postsAMostrar.Add(post);
                                }
                            }
                        }
                    }

                }
            }
            else if(administradorLogeado is Administrador)
            {
                foreach(Publicacion publicacion in publicaciones)
                {
                    if(publicacion is Post)
                    {
                        Post post = publicacion as Post;
                        postsAMostrar.Add(post);
                    }
                }
            }
           
            ViewBag.Posts = postsAMostrar;
            return View();
        }
        [HttpPost]
        public IActionResult Censurar(int postId)
        {
            Sistema.Instancia.CensurarPost(postId, true);
            ViewBag.Mensaje = "Se ha censurado el post con ID " + postId;
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Login", "Login", new { mensaje = "no tienes acceso" });
            }

            Administrador administradorLogeado = Sistema.Instancia.GetAdministradorByEmail(HttpContext.Session.GetString("usuario"));

            Miembro miembroLogeado = Sistema.Instancia.GetMiembroByEmail(HttpContext.Session.GetString("usuario"));

            if (miembroLogeado is Miembro)
            {
                ViewBag.Nombre = miembroLogeado.Nombre + " " + miembroLogeado.Apellido;
                ViewBag.IsAdmin = false;
            }
            else if (administradorLogeado is Administrador)
            {
                ViewBag.Nombre = administradorLogeado.Nombre + " " + administradorLogeado.Apellido;
                ViewBag.IsAdmin = true;
            }

            List<Publicacion> publicaciones = Sistema.Instancia.GetPublicaciones();
            List<Post> postsAMostrar = new List<Post>();
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
                                postsAMostrar.Add(post);
                            }
                            else if (post.Autor == miembroLogeado)
                            {
                                postsAMostrar.Add(post);
                            }
                            foreach (Miembro amigo in miembroLogeado.GetListaDeAmigos())
                            {
                                if (amigo == post.Autor)
                                {
                                    postsAMostrar.Add(post);
                                }
                            }
                        }
                    }

                }
            }
            else if (administradorLogeado is Administrador)
            {
                foreach (Publicacion publicacion in publicaciones)
                {
                    if (publicacion is Post)
                    {
                        Post post = publicacion as Post;
                        postsAMostrar.Add(post);
                    }
                }
            }

            ViewBag.Posts = postsAMostrar;
            
            return View("Index");
        }
        [HttpPost]
        public IActionResult Descensurar(int postId)
        {
            Sistema.Instancia.CensurarPost(postId, false);
            ViewBag.Mensaje = "Se ha descensurado el post con ID " + postId;
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Login", "Login", new { mensaje = "no tienes acceso" });
            }

            Administrador administradorLogeado = Sistema.Instancia.GetAdministradorByEmail(HttpContext.Session.GetString("usuario"));

            Miembro miembroLogeado = Sistema.Instancia.GetMiembroByEmail(HttpContext.Session.GetString("usuario"));

            if (miembroLogeado is Miembro)
            {
                ViewBag.Nombre = miembroLogeado.Nombre + " " + miembroLogeado.Apellido;
                ViewBag.IsAdmin = false;
            }
            else if (administradorLogeado is Administrador)
            {
                ViewBag.Nombre = administradorLogeado.Nombre + " " + administradorLogeado.Apellido;
                ViewBag.IsAdmin = true;
            }

            List<Publicacion> publicaciones = Sistema.Instancia.GetPublicaciones();
            List<Post> postsAMostrar = new List<Post>();
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
                                postsAMostrar.Add(post);
                            }
                            else if (post.Autor == miembroLogeado)
                            {
                                postsAMostrar.Add(post);
                            }
                            foreach (Miembro amigo in miembroLogeado.GetListaDeAmigos())
                            {
                                if (amigo == post.Autor)
                                {
                                    postsAMostrar.Add(post);
                                }
                            }
                        }
                    }

                }
            }
            else if (administradorLogeado is Administrador)
            {
                foreach (Publicacion publicacion in publicaciones)
                {
                    if (publicacion is Post)
                    {
                        Post post = publicacion as Post;
                        postsAMostrar.Add(post);
                    }
                }
            }

            ViewBag.Posts = postsAMostrar;

            return View("Index");
        }
    }
}
