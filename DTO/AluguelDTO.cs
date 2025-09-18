using SistemaPredio.Enum;

namespace SistemaPredio.DTO;

public class AluguelDTO
{
    public int Id { get; set; }
    public string cpfMorador { get; set; }
    
    public string codigoApartamento { get; set; }
    
    public decimal Preco { get; set; }
    
    public DateTime DataVencimento  { get; set; }
    
    public DateTime DataPagamento { get; set; }
    
    public Pago Pago { get; set; }
}