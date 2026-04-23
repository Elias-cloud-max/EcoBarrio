using EcoBarrio.Domain.Entities;

namespace EcoBarrio.Infrastructure.Contracts;

public interface IUsuarioRepository
{
    Task<List<Usuario>> ObtenerTodos();
    Task<Usuario?> ObtenerPorId(int id);
    Task Crear(Usuario usuario);
    Task Actualizar(Usuario usuario);
    Task Eliminar(Usuario usuario);
}