using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
    
    [JsonIgnore]
    public Usuario Usuario { get; set; }
    
    [JsonIgnore]
    public List<Aluguel> Alugueis { get; set; }
}