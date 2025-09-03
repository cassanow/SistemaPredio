using SistemaPredio.DTO;
using SistemaPredio.Model;

namespace SistemaPredio.Interface;

public interface ITokenService
{
    TokenResponse GenerateToken(Usuario usuario);
}