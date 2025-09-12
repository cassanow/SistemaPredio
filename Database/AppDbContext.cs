using Microsoft.EntityFrameworkCore;
using SistemaPredio.Model;

namespace SistemaPredio.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    public DbSet<Aluguel> Aluguel { get; set; }
    public DbSet<Apartamento> Apartamento { get; set; }
    public DbSet<Morador> Morador { get; set; }
    public DbSet<Usuario> Usuario { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Aluguel>()
            .HasOne(a => a.Morador)
            .WithMany(m => m.Alugueis)
            .HasForeignKey(a => a.cpfMorador)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Aluguel>()
            .HasOne(a => a.Apartamento)
            .WithMany(a => a.Alugueis)
            .HasForeignKey(a => a.codigoApartamento)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Aluguel>()
            .Property(a => a.Preco)
            .HasColumnType("decimal(18,2)");
        
        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.CPF)
            .IsUnique();
        
        modelBuilder.Entity<Morador>()
            .HasOne(m => m.Usuario)
            .WithOne()
            .HasForeignKey<Morador>(m => m.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Morador>()
            .HasMany(m => m.Alugueis)
            .WithOne(a => a.Morador)
            .HasForeignKey(a => a.cpfMorador)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Apartamento>()
            .HasOne(a => a.Morador)
            .WithMany()
            .HasForeignKey(a => a.cpfMorador)
            .OnDelete(DeleteBehavior.SetNull);
        
        modelBuilder.Entity<Apartamento>()
            .HasMany(a => a.Alugueis)
            .WithOne(aluguel => aluguel.Apartamento)
            .HasForeignKey(aluguel => aluguel.codigoApartamento)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}