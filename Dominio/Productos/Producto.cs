using System;
using Dominio.Productos;
using Dominio.Proveedores;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Productos
{
    public class Producto
    {
        [Required,Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProducto { get; set; }
        [Required,MaxLength(100)]
        public string NombreProducto { get; set; }
        [MaxLength(350)]
        public string DescripcionProducto { get; set; }
        [Required]
        public int PrecioMayorista { get; set; }
        [Required]
        public int PrecioTotal { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string NombreBusqueda { get; set; }

        [Required]
        public Categoria Categoria { get; set; }
        [Required]
        public Medida Medida { get; set; }
        [Required]
        public Proveedor Proveedor { get; set; }
    }
}
