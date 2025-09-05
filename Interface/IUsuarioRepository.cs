using SistemaPredio.DTO;
using SistemaPredio.Model;

namespace SistemaPredio.Interface;

public interface IUsuarioRepository
{
    Task <List<Usuario>> GetAll();
    Task<Usuario> GetById(int id);
    Task<Usuario> GetByCPF(string cpf);
    Task<bool> UserExists(string CPF);
    Task<Usuario> Post(Usuario usuario);
    Task<UsuarioDTO> Put(UsuarioDTO usuario);
    Task Delete(Usuario usuario);
}