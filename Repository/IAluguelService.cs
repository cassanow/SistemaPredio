using SistemaPredio.Model;

namespace SistemaPredio.Repository;

public interface IAluguelService
{
    decimal JurosAluguel(Aluguel aluguel);
}