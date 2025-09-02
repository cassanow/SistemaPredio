using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaPredio.Model;

public class Morador
{
    [Key]
    [StringLength(11,  MinimumLength = 11)]
    public string CPF { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }
    
    [Required]
    [StringLength(11, MinimumLength = 11)]
    public string Telefone { get; set; }
    
    [ForeignKey(nameof(Usuario))]
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    
    public List<Aluguel> Alugueis { get; set; }
}