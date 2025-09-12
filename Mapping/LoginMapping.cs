using SistemaPredio.DTO;
using SistemaPredio.Model;

namespace SistemaPredio.Mapping;

public class LoginMapping
{
    public static Usuario Tologin(LoginDTO login)
    {
        return new Usuario
        {
            Email = login.Email,
            Senha = login.Senha,
        };
    }

    public static LoginDTO ToUsuario(Usuario usuario)
    {
        return new LoginDTO
        {
            Email = usuario.Email,
            Senha = usuario.Senha,
        };
    }
}