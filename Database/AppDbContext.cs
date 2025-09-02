using Microsoft.EntityFrameworkCore;

namespace SistemaPredio.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
}