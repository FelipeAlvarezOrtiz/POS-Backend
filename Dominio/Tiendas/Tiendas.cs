using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Tiendas
{
    public class Tiendas
    {
        [Required,Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTienda { get; set; }
        [Required,MaxLength(100)]
        public string NombreTienda { get; set; }

        public int IdTipoTienda { get; set; }
        public TipoTienda TipoTienda { get; set; }
    }
}
