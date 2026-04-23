using EcoBarrio.Domain.Entities;
using EcoBarrio.Infrastructure.Contracts;
using EcoBarrio.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoBarrio.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly EcoBarrioDbContext _context;

    public UsuarioRepository(EcoBarrioDbContext context)
    {
        _context = context;
    }

    public async Task<List<Usuario>> ObtenerTodos()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<Usuario?> ObtenerPorId(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task Crear(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task Actualizar(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task Eliminar(Usuario usuario)
    {
        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
    }
}