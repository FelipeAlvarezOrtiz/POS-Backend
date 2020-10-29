using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Proveedores
{
    public class ContactoProveedor
    {
        public Proveedor Proveedor { get; set; }

        [Required,Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdContacto { get; set; }
        [MaxLength(80),DataType(DataType.EmailAddress)]
        public string CorreoProveedor { get; set; }
        [DataType(DataType.PhoneNumber),MaxLength(25)]
        public string TelefonoProveedor { get; set; }
    }
}
