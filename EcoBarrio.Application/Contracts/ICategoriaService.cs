using EcoBarrio.Application.DTOs;

namespace EcoBarrio.Application.Contracts;

public interface ICategoriaService
{
    Task<List<CategoriaDto>> ObtenerTodos();
    Task<CategoriaDto?> ObtenerPorId(int id);
    Task Crear(CrearCategoriaDto dto);
    Task Actualizar(int id, CrearCategoriaDto dto);
    Task Eliminar(int id);
}