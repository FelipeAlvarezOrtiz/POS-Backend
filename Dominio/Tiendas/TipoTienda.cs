using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Tiendas
{
    public class TipoTienda
    {
        [Required,Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoTienda { get; set; }
        [Required,MaxLength(100)]
        public string NombreTienda { get; set; }
    }
}
