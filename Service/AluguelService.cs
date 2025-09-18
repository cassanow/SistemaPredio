using SistemaPredio.Interface;
using SistemaPredio.Model;
using SistemaPredio.Repository;

namespace SistemaPredio.Service;

public class AluguelService : IAluguelService
{
    private readonly IAluguelRepository _aluguelRepository;

    public AluguelService(IAluguelRepository aluguelRepository)
    {
        _aluguelRepository = aluguelRepository;
    }
    
    public decimal JurosAluguel(Aluguel aluguel)
    {
        var diasAtraso = (aluguel.DataPagamento - aluguel.DataVencimento).Days;
        const decimal taxaDiaria = 0.005m;

        if (diasAtraso <= 0) return aluguel.Preco;
        
        var juros = aluguel.Preco * diasAtraso * taxaDiaria;
        var novoAluguel = aluguel.Preco + juros;
        return novoAluguel;
    }

}