using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.Clientes;

namespace Dominio.Trabajadores
{
    public class Trabajador
    {
        [Required,Key,DatabaseGenerated(databaseGeneratedOption:DatabaseGeneratedOption.Identity)]
        public int IdTrabajador{ get; set; }
        [Required,MaxLength(100)]
        public string NombreTrabajador { get; set; }
        [MaxLength(150)]
        public string Direccion { get; set; }

        public int IdComuna { get; set; }
        public Comuna Comuna { get; set; }
        
        public int IdRegion { get; set; }
        public Region Region { get; set; }

        public int IdSector { get; set; }
        public Sector Sector { get; set; }
    }
}
