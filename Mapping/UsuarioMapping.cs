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
            Nome = usuarioDTO.Nome,
            Senha = usuarioDTO.Senha,
            CPF = usuarioDTO.CPF,
            Role = Role.Morador,
        };
    }

    public static UsuarioDTO ToDTO(Usuario usuario)
    {
        return new UsuarioDTO
        {
            Nome = usuario.Nome,
            Senha = usuario.Senha,
            CPF = usuario.CPF,
        };
    }
}