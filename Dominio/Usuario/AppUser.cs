using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Dominio.Usuario
{
    public class AppUser : IdentityUser
    {
        [Required,MaxLength(75)] public string Nombre { get; set; }
        [Required,MaxLength(12),MinLength(12)]public string RutUsuario { get; set; }
        [Required,MaxLength(40)]public string Contacto { get; set; }
        [Required,MaxLength(100)]public string Correo { get; set; }
        [Required,MaxLength(100)]public string Ubicacion { get; set; }
    }
}
