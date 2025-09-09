using Microsoft.EntityFrameworkCore;
using SistemaPredio.Database;
using SistemaPredio.Interface;
using SistemaPredio.Model;

namespace SistemaPredio.Repository;

public class MoradorRepository : IMoradorRepository
{
    private readonly AppDbContext _context;

    public MoradorRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Morador>> GetAllMoradores()
    {
       return await _context.Morador.ToListAsync();
    }

    public async Task<Morador> GetByCPF(string cpf)
    {
        return await _context.Morador.FirstOrDefaultAsync(m => m.CPF == cpf);
    }

    public async Task<Morador> GetByUsuarioId(int usuarioId)
    {
       return await _context.Morador.FirstOrDefaultAsync(m => m.UsuarioId == usuarioId);
    }

    public async Task<bool> MoradorExists(string cpf)
    {
        return await _context.Morador.AnyAsync(m => m.CPF == cpf);
    }

    public async Task<Morador> Post(Morador morador)
    {
        _context.Morador.Add(morador);
        await _context.SaveChangesAsync();
        return morador;
    }

    public async Task<Morador> Put(Morador morador)
    {
        _context.Entry(morador).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return morador;
    }

    public async Task Delete(Morador morador)
    {
        _context.Morador.Remove(morador);
        await _context.SaveChangesAsync();
    }
}
