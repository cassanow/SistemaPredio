using SistemaPredio.DTO;
using SistemaPredio.Model;

namespace SistemaPredio.Mapping;

public class UsuarioMapping
{
    public static Usuario ToDTO(UsuarioDTO usuarioDTO)
    {
        return new Usuario
        {
            Nome = usuarioDTO.Nome,
            Senha = usuarioDTO.Senha,
            CPF = usuarioDTO.CPF,
        };
    }

    public static UsuarioDTO ToUsuario(Usuario usuario)
    {
        return new UsuarioDTO
        {
            Nome = usuario.Nome,
            Senha = usuario.Senha,
            CPF = usuario.CPF,
        };
    }
}