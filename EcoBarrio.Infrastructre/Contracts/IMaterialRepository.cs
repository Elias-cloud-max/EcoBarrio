using EcoBarrio.Domain.Entities;

namespace EcoBarrio.Infrastructure.Contracts;

public interface IMaterialRepository
{
    Task<List<Material>> ObtenerTodos();
    Task<Material?> ObtenerPorId(int id);
    Task Crear(Material material);
    Task Actualizar(Material material);
    Task Eliminar(Material material);
}