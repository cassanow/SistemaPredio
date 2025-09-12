using SistemaPredio.DTO;
using SistemaPredio.Enum;
using SistemaPredio.Model;

namespace SistemaPredio.Mapping;

public class UsuarioMapping
{
    public static Usuario ToUsuario(UsuarioDTO usuarioDTO)
    {
        return new Usuario
        {
            Email = usuarioDTO.Email,
            Senha = usuarioDTO.Senha,
            CPF = usuarioDTO.CPF,
            Role = Role.Morador,
        };
    }

    public static UsuarioDTO ToDTO(Usuario usuario)
    {
        return new UsuarioDTO
        {
            Email = usuario.Email,
            Senha = usuario.Senha,
            CPF = usuario.CPF,
        };
    }
}