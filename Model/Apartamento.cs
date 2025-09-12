using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaPredio.Model;

public class Apartamento
{
    [Key]
    [StringLength(5, MinimumLength = 5)]
    public string Codigo { get; set; }
    
    [Required]
    public int Andar { get; set; }
    
    [ForeignKey(nameof(Morador))]
    [StringLength(11, MinimumLength = 11)]
    public string? cpfMorador { get; set; }
    public Morador Morador { get; set; }
    public List<Aluguel> Alugueis { get; set; }
}