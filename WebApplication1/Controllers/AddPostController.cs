using Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;



namespace WebApplication1.Controllers
{
    public class AddPostController : Controller
    {
        private readonly ILogger<AddPostController> _logger;
        private IWebHostEnvironment _environment;

        public AddPostController(ILogger<AddPostController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public IActionResult AddPost(string mensaje)
        {
            ViewBag.MensajeExito = mensaje;
            return View("AddPost");
        }

        [HttpPost]
        public IActionResult AddPost(string Titulo, string Texto, bool Publico, IFormFile Image)
        {

            string rutaFisicaWwwRoot = _environment.WebRootPath;
            string nombreImagen = Image.FileName;
            string rutaFisicaFoto = Path.Combine(rutaFisicaWwwRoot, "Images", nombreImagen);
            Miembro miembroLogeado = Sistema.Instancia.GetMiembroByEmail(HttpContext.Session.GetString("usuario"));
            try
            {
                Sistema.Instancia.AgregarPostMiembro(miembroLogeado.Id, Titulo, Texto, nombreImagen, Publico);
                using(FileStream f = new FileStream(rutaFisicaFoto, FileMode.Create))
                {
                    Image.CopyTo(f);
                }
                return RedirectToAction("Index", "Home", new { mensajeExito = "Post creado con exito" });
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }

        }
    }
}
