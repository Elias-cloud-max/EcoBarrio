using EcoBarrio.Application.DTOs;

namespace EcoBarrio.Application.Contracts;

public interface IUsuarioService
{
    Task<List<UsuarioDto>> ObtenerTodos();
    Task<UsuarioDto?> ObtenerPorId(int id);
    Task Crear(CrearUsuarioDto dto);
    Task Actualizar(int id, CrearUsuarioDto dto);
    Task Eliminar(int id);
}