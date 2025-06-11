using Gestion_ProductosT.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gestion_ProductosT.Controllers
{
    public class productoController : Controller
    {
        public readonly AppDbContext _context;

        public productoController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            try
            {
                var producto = _context.productos.Find();
                return View(producto);
            }
            catch (DbUpdateException ex)
            {
                return Content($"Error de conexion de base de datos {ex.Message}");
            }
            catch (Exception ex)
            {
                return Content("Excepcion no controlada :" + ex.Message);
            }
            return View();
        }
    }
}
