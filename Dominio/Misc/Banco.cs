using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Misc
{
    public class Banco
    {
        [Required,Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBanco { get; set; }
        [Required,MaxLength(100)]
        public string NombreBanco { get; set; }
    }
}
