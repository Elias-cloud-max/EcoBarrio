using EcoBarrio.Domain.Entities;

namespace EcoBarrio.Infrastructure.Contracts;

public interface ICategoriaRepository
{
    Task<List<Categoria>> ObtenerTodos();
    Task<Categoria?> ObtenerPorId(int id);
    Task Crear(Categoria categoria);
    Task Actualizar(Categoria categoria);
    Task Eliminar(Categoria categoria);
}