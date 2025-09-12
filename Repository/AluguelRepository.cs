using Microsoft.EntityFrameworkCore;
using SistemaPredio.Database;
using SistemaPredio.Interface;
using SistemaPredio.Model;

namespace SistemaPredio.Repository;

public class AluguelRepository : IAluguelRepository
{
    private readonly AppDbContext _context;

    public AluguelRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Aluguel>> GetAll()
    {
        return await _context.Aluguel.ToListAsync();
    }

    public async Task<Aluguel> GetByCPF(string cpf)
    {
        return await _context.Aluguel.Where(a => a.cpfMorador == cpf).FirstOrDefaultAsync();
    }

    public async Task<Aluguel> Post(Aluguel aluguel)
    {
        _context.Aluguel.Add(aluguel);
        await _context.SaveChangesAsync();
        return aluguel;
    }

    public async Task<Aluguel> Put(Aluguel aluguel)
    {
        _context.Entry(aluguel).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return aluguel;
    }

    public async Task Delete(Aluguel aluguel)
    {
        _context.Aluguel.Remove(aluguel);
        await _context.SaveChangesAsync();
    }
}