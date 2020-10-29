using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Proveedores
{
    public class TipoProveedor
    {
        [Required,Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoProveedor { get; set; }
        [Required,MaxLength(50)]
        public string NombreTipoProveedor { get; set; }
    }
}
