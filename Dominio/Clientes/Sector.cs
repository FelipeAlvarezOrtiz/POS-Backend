using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Clientes
{
    public class Sector
    {
        [Required,Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSector { get; set; }
        [Required]
        public string NombreSector { get; set; }
    }
}
