using SistemaPredio.Model;

namespace SistemaPredio.Interface;

public interface IMoradorRepository
{
    Task<List<Morador>> GetAllMoradores();
    
    Task<Morador> GetByCPF(string cpf);
    
    Task<bool> MoradorExists(string cpf);
    
    Task<Morador> GetByUsuarioId(int usuarioId);
    
    Task<Morador> Post(Morador morador);
    
    Task<Morador> Put(Morador morador);
    
    Task Delete(Morador morador);
}