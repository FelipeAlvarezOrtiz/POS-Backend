using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Misc
{
    public class TipoPago
    {
        [Required,Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoPago { get; set; }
        [Required,MaxLength(25)]
        public string NombreTipoPago { get; set; }
    }
}
