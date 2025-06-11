using Microsoft.AspNetCore.Mvc;

namespace Gestion_ProductosT.Controllers
{
    public class productoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
