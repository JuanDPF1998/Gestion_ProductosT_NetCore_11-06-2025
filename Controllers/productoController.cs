using Gestion_ProductosT.Data;
using Gestion_ProductosT.Models;
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
                var producto = _context.productos.ToList();
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
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductosModel productos)
        {
            if (ModelState.IsValid)
            {
                _context.productos.Add(productos);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(productos);
        }
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var producto = _context.productos.Find(id);
            return View(producto);
        }
        [HttpPost]
        public IActionResult Edit(int id, ProductosModel productos)
        {
            if (id != productos.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.productos.Update(productos);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(productos);
        }
       public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var producto = _context.productos.Find(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var producto = _context.productos.Find(id);
                if (ModelState.IsValid)
                {
                    _context.productos.Remove(producto);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch (Exception ex)
            {
                return Content("Error al eliminar el producrto :" + ex.Message);
            }
            
        }
    }
}
