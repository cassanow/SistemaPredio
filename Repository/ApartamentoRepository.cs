using Microsoft.EntityFrameworkCore;
using SistemaPredio.Database;
using SistemaPredio.Interface;
using SistemaPredio.Model;

namespace SistemaPredio.Repository;

public class ApartamentoRepository : IApartamentoRepository
{
    private readonly AppDbContext _context;

    public ApartamentoRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Apartamento>> GetAll()
    {
        return await _context.Apartamento.Include(a => a.Morador).Include(a => a.Alugueis).ToListAsync();
    }

    public async Task<Apartamento> GetByCPF(string cpf)
    {
        return await _context.Apartamento
            .Include(a => a.Morador)
            .Include(a => a.Alugueis)
            .Where(a => a.cpfMorador == cpf)
            .FirstOrDefaultAsync();
    }

    public async Task<Apartamento> GetByCodigo(string codigo)
    {
        return await _context.Apartamento.Where(a => a.Codigo == codigo).FirstOrDefaultAsync();
    }

    public async Task<Apartamento> Post(Apartamento apartamento)
    {
        _context.Apartamento.Add(apartamento);
        await _context.SaveChangesAsync();
        return apartamento;
    }

    public async Task<Apartamento> Put(Apartamento apartamento)
    {
        _context.Entry(apartamento).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return apartamento;
    }

    public async Task Delete(Apartamento apartamento)
    {
        _context.Apartamento.Remove(apartamento);
        await _context.SaveChangesAsync();
    }
}