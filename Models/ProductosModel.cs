using System.ComponentModel.DataAnnotations;

namespace Gestion_ProductosT.Models
{
    public class ProductosModel
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string Stock { get; set; } = string.Empty;
    }
}
