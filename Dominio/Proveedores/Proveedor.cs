using Dominio.Misc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Proveedores
{
    public class Proveedor
    {
        [Required,Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProveedor { get; set; }
        [Required,MaxLength(100)]
        public string NombreProveedor { get; set; }
        [Required,MaxLength(15)]
        public string RutProveedor { get; set; }
        [MaxLength(150)]
        public string Ubicacion { get; set; }
        [Required]
        public int DiaFacturacion { get; set; }
        [Required]
        public string NumeroCuenta { get; set; }

        [Required]
        public TipoProveedor TipoProveedor { get; set; }

        [Required]
        public Banco Banco { get; set; }

        [Required]
        public TipoPago TipoPago { get; set; }

        [Required]
        public TipoCuenta TipoCuenta { get; set; }

        public List<ContactoProveedor> Contacto { get; set; }
    }
}
