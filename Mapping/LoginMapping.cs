using SistemaPredio.DTO;
using SistemaPredio.Model;

namespace SistemaPredio.Mapping;

public class LoginMapping
{
    public static Usuario Tologin(LoginDTO login)
    {
        return new Usuario
        {
            CPF = login.CPF,
            Senha = login.Senha,
        };
    }

    public static LoginDTO ToUsuario(Usuario usuario)
    {
        return new LoginDTO
        {
            CPF = usuario.CPF,
            Senha = usuario.Senha,
        };
    }
}