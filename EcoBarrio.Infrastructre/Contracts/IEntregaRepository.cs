using EcoBarrio.Domain.Entities;

namespace EcoBarrio.Infrastructure.Contracts;

public interface IEntregaRepository
{
    Task<List<Entrega>> ObtenerTodos();
    Task<Entrega?> ObtenerPorId(int id);
    Task Crear(Entrega entrega);
    Task Actualizar(Entrega entrega);
    Task Eliminar(Entrega entrega);
}