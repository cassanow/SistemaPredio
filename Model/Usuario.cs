using System.ComponentModel.DataAnnotations;
using SistemaPredio.Enum;

namespace SistemaPredio.Model;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [StringLength(11, MinimumLength = 11)]
    public string CPF { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Senha { get; set; }
    
    public Role Role { get; set; }
}