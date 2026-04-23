using EcoBarrio.Domain.Entities;
using EcoBarrio.Infrastructure.Contracts;
using EcoBarrio.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoBarrio.Infrastructure.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly EcoBarrioDbContext _context;

    public CategoriaRepository(EcoBarrioDbContext context)
    {
        _context = context;
    }

    public async Task<List<Categoria>> ObtenerTodos()
    {
        return await _context.Categorias.ToListAsync();
    }

    public async Task<Categoria?> ObtenerPorId(int id)
    {
        return await _context.Categorias.FindAsync(id);
    }

    public async Task Crear(Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();
    }

    public async Task Actualizar(Categoria categoria)
    {
        _context.Categorias.Update(categoria);
        await _context.SaveChangesAsync();
    }

    public async Task Eliminar(Categoria categoria)
    {
        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync();
    }
}