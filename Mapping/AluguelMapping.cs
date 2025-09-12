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
            Pago = aluguel.Pago,
            Preco = aluguel.Preco,
        };
    }
}