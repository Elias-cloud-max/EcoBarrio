using EcoBarrio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EcoBarrio.Infrastructure.Data;

public class EcoBarrioDbContext : DbContext
{
    public EcoBarrioDbContext(DbContextOptions<EcoBarrioDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Material> Materiales { get; set; }
    public DbSet<Entrega> Entregas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Entregas)
            .WithOne(e => e.Usuario)
            .HasForeignKey(e => e.UsuarioId);

        modelBuilder.Entity<Categoria>()
            .HasMany(c => c.Materiales)
            .WithOne(m => m.Categoria)
            .HasForeignKey(m => m.CategoriaId);

        modelBuilder.Entity<Material>()
            .HasMany(m => m.Entregas)
            .WithOne(e => e.Material)
            .HasForeignKey(e => e.MaterialId);
    }
}