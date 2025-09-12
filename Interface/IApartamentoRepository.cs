using SistemaPredio.Model;

namespace SistemaPredio.Interface;

public interface IApartamentoRepository
{
    Task<List<Apartamento>> GetAll();
    
    Task<Apartamento> GetByCPF(string cpf);
    
    Task<Apartamento> GetByCodigo(string codigo);
    
    Task<Apartamento> Post(Apartamento apartamento);
    
    Task<Apartamento> Put(Apartamento apartamento);
    
    Task Delete(Apartamento apartamento);
}