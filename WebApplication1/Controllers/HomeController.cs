using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.nombre = "Pedro Paez";
            return View();
        }
    }
}
