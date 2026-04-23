using EcoBarrio.Domain.Entities;
using EcoBarrio.Infrastructure.Contracts;
using EcoBarrio.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoBarrio.Infrastructure.Repositories;

public class MaterialRepository : IMaterialRepository
{
    private readonly EcoBarrioDbContext _context;

    public MaterialRepository(EcoBarrioDbContext context)
    {
        _context = context;
    }

    public async Task<List<Material>> ObtenerTodos()
    {
        return await _context.Materiales
            .Include(m => m.Categoria)
            .ToListAsync();
    }

    public async Task<Material?> ObtenerPorId(int id)
    {
        return await _context.Materiales
            .Include(m => m.Categoria)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task Crear(Material material)
    {
        _context.Materiales.Add(material);
        await _context.SaveChangesAsync();
    }

    public async Task Actualizar(Material material)
    {
        _context.Materiales.Update(material);
        await _context.SaveChangesAsync();
    }

    public async Task Eliminar(Material material)
    {
        _context.Materiales.Remove(material);
        await _context.SaveChangesAsync();
    }
}