using SistemaPredio.Model;

namespace SistemaPredio.Interface;

public interface IAluguelRepository
{
    Task<List<Aluguel>> GetAll();
    
    Task<Aluguel> GetByCPF(string cpf);

    Task<Aluguel> Post(Aluguel aluguel);
    
    Task<Aluguel> Put(Aluguel aluguel);
    
    Task Delete(Aluguel aluguel);
}