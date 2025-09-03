using Microsoft.EntityFrameworkCore;
using SistemaPredio.Database;
using SistemaPredio.DTO;
using SistemaPredio.Interface;
using SistemaPredio.Model;

namespace SistemaPredio.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task <List<Usuario>> GetAll()
    {
        return await _context.Usuario.ToListAsync();
    }

    public async Task<Usuario> GetById(int id)
    {
        return await _context.Usuario.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<bool> UserExists(string CPF)
    {
        return await _context.Usuario.AnyAsync(u => u.CPF == CPF);
    }

    public async Task<Usuario> Post(Usuario usuario)
    {
        await _context.Usuario.AddAsync(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<UsuarioDTO> Put(UsuarioDTO usuario)
    {
        _context.Entry(usuario).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task Delete(Usuario usuario)
    {
        _context.Remove(usuario);
        await _context.SaveChangesAsync();
    }
}