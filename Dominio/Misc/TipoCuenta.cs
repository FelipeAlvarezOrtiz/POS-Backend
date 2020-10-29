using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Misc
{
    public class TipoCuenta
    {
        [Required,Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoCuenta { get; set; }
        [Required,MaxLength(50)]
        public string NombreTipoCuenta { get; set; }
    }
}
