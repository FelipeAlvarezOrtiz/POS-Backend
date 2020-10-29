using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Clientes
{
    public class Cliente
    {
        [Required,Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }
        [Required]
        public int RutCliente { get; set; }

        [Required,MaxLength(100)]
        public string NombreCliente { get; set; }
        [MaxLength(150)]
        public string DireccionCliente { get; set; }

        public int IdRegion { get; set; }
        public Region Region { get; set; }

        public int IdComuna { get; set; }
        public Comuna Comuna { get; set; }

        public int IdSector { get; set; }
        public Sector Sector { get; set; }
    }
}
