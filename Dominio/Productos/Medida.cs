using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Productos
{
    public class Medida
    {
        [Required,Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMedida { get; set; }
        [Required,MaxLength(60),MinLength(5)]
        public string NombreMedida { get; set; }
        [DataType(DataType.Date), Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaCreacion { get; set; }
    }
}
