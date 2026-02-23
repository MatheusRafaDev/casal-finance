using Microsoft.EntityFrameworkCore;
using CasalFinance.Models;

namespace CasalFinance.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Beneficio> Beneficios { get; set; }
    public DbSet<Receita> Receitas { get; set; }
    public DbSet<Gasto> Gastos { get; set; }
    public DbSet<Custo> Custos { get; set; }
    public DbSet<Economia> Economias { get; set; }
    public DbSet<Futuro> Futuros { get; set; }
    public DbSet<Parcelado> Parcelados { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Receita>().HasIndex(r => r.Data);
        modelBuilder.Entity<Gasto>().HasIndex(g => g.Data);
        modelBuilder.Entity<Futuro>().HasIndex(f => f.Data);
        modelBuilder.Entity<Parcelado>().HasIndex(p => p.DataPrimeira);
        modelBuilder.Entity<Futuro>().HasIndex(f => f.ParcelaRef);
    }
}