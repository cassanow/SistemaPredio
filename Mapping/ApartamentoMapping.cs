using SistemaPredio.DTO;
using SistemaPredio.Model;

namespace SistemaPredio.Mapping;

public class ApartamentoMapping
{
    public static Apartamento ToApartamento(ApartamentoDTO dto)
    {
        return new Apartamento
        {
            Codigo = dto.Codigo,
            Andar = dto.Andar,
            cpfMorador = dto.cpfMorador
        };
    }

    public static ApartamentoDTO ToDTO(Apartamento apartamento)
    {
        return new ApartamentoDTO
        {
            Codigo = apartamento.Codigo,
            Andar = apartamento.Andar,
            cpfMorador = apartamento.cpfMorador,
        };
    }
}