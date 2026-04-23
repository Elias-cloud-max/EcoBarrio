using EcoBarrio.Domain.Entities;
using EcoBarrio.Infrastructure.Contracts;
using EcoBarrio.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoBarrio.Infrastructure.Repositories;

public class EntregaRepository : IEntregaRepository
{
    private readonly EcoBarrioDbContext _context;

    public EntregaRepository(EcoBarrioDbContext context)
    {
        _context = context;
    }

    public async Task<List<Entrega>> ObtenerTodos()
    {
        return await _context.Entregas
            .Include(e => e.Usuario)
            .Include(e => e.Material)
            .ToListAsync();
    }

    public async Task<Entrega?> ObtenerPorId(int id)
    {
        return await _context.Entregas
            .Include(e => e.Usuario)
            .Include(e => e.Material)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task Crear(Entrega entrega)
    {
        _context.Entregas.Add(entrega);
        await _context.SaveChangesAsync();
    }

    public async Task Actualizar(Entrega entrega)
    {
        _context.Entregas.Update(entrega);
        await _context.SaveChangesAsync();
    }

    public async Task Eliminar(Entrega entrega)
    {
        _context.Entregas.Remove(entrega);
        await _context.SaveChangesAsync();
    }
}