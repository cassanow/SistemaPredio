using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaPredio.Model;

public class Admin
{
    [Key]
    public int Id { get; set; }
    
    [ForeignKey(nameof(Usuario))]
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    
    public string Nome { get; set; }
}