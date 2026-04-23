using EcoBarrio.Application.DTOs;

namespace EcoBarrio.Application.Contracts;

public interface IMaterialService
{
    Task<List<MaterialDto>> ObtenerTodos();
    Task<MaterialDto?> ObtenerPorId(int id);
    Task Crear(CrearMaterialDto dto);
    Task Actualizar(int id, CrearMaterialDto dto);
    Task Eliminar(int id);
}