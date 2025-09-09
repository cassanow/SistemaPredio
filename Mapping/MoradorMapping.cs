using SistemaPredio.DTO;
using SistemaPredio.Model;

namespace SistemaPredio.Mapping;

public class MoradorMapping
{
    public static Morador ToMorador(MoradorDTO dto)
    {
        return new Morador
        {
            Nome = dto.Nome,
            CPF = dto.CPF,
            Telefone = dto.Telefone,
        };
    }

    public static MoradorDTO ToDTO(Morador morador)
    {
        return new MoradorDTO
        {
            Nome = morador.Nome,
            CPF = morador.CPF,
            Telefone = morador.Telefone,
        };
    }
}