using Dominio.Usuario;

namespace Aplicacion.Interfaces
{
    public interface IJwtGenerator
    {
        string CreateToken(AppUser user);
    }
}
