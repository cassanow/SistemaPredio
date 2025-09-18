using SistemaPredio.DTO;
using SistemaPredio.Model;

namespace SistemaPredio.Mapping;

public class AluguelMapping
{
    public static Aluguel ToAluguel(AluguelDTO dto)
    {
        return new Aluguel
        {
            Id = dto.Id,
            cpfMorador = dto.cpfMorador,
            codigoApartamento = dto.codigoApartamento,
            DataVencimento = dto.DataVencimento,
            DataPagamento = dto.DataPagamento,
            Pago = dto.Pago,
            Preco = dto.Preco,
        };
    }

    public static AluguelDTO ToDTO(Aluguel aluguel)
    {
        return new AluguelDTO
        {
            cpfMorador = aluguel.cpfMorador,
            codigoApartamento = aluguel.codigoApartamento,
            DataVencimento = aluguel.DataVencimento,
            DataPagamento = aluguel.DataPagamento,      
            Pago = aluguel.Pago,
            Preco = aluguel.Preco,
        };
    }
}