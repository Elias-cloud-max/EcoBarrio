using EcoBarrio.Application.DTOs;

namespace EcoBarrio.Application.Contracts;

public interface IEntregaService
{
    Task<List<EntregaDto>> ObtenerTodos();
    Task<EntregaDto?> ObtenerPorId(int id);
    Task Crear(CrearEntregaDto dto);
    Task Actualizar(int id, CrearEntregaDto dto);
    Task Eliminar(int id);
}