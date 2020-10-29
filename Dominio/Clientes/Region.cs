using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Clientes
{
    public class Region
    {
        [Required,Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRegion { get; set; }
        [Required]
        public string NombreRegion { get; set; }
    }
}
