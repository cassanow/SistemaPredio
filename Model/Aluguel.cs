using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SistemaPredio.Model;

public class Aluguel
{
    [Key]
    public int Id { get; set; }
    
    [ForeignKey(nameof(Apartamento))] 
    public string codigoApartamento { get; set; }
    public Apartamento Apartamento { get; set; }
    
    [ForeignKey(nameof(Morador))]
    [StringLength(11, MinimumLength = 11)]
    public string? cpfMorador { get; set; }
    
    [JsonIgnore]
    public Morador Morador { get; set; }
    public decimal Preco { get; set; }
    
    public DateTime DataVencimento { get; set; }
}