using EcoBarrio.Application.Contracts;
using EcoBarrio.Application.DTOs;
using EcoBarrio.Domain.Entities;
using EcoBarrio.Infrastructure.Contracts;

namespace EcoBarrio.Application.Services;

public class EntregaService : IEntregaService
{
    private readonly IEntregaRepository _entregaRepository;

    public EntregaService(IEntregaRepository entregaRepository)
    {
        _entregaRepository = entregaRepository;
    }

    public async Task<List<EntregaDto>> ObtenerTodos()
    {
        var entregas = await _entregaRepository.ObtenerTodos();

        return entregas.Select(e => new EntregaDto
        {
            Id = e.Id,
            UsuarioId = e.UsuarioId,
            UsuarioNombre = e.Usuario != null ? e.Usuario.Nombre : "",
            MaterialId = e.MaterialId,
            MaterialNombre = e.Material != null ? e.Material.Nombre : "",
            PesoKg = e.PesoKg,
            FechaEntrega = e.FechaEntrega
        }).ToList();
    }

    public async Task<EntregaDto?> ObtenerPorId(int id)
    {
        var entrega = await _entregaRepository.ObtenerPorId(id);

        if (entrega == null)
            return null;

        return new EntregaDto
        {
            Id = entrega.Id,
            UsuarioId = entrega.UsuarioId,
            UsuarioNombre = entrega.Usuario != null ? entrega.Usuario.Nombre : "",
            MaterialId = entrega.MaterialId,
            MaterialNombre = entrega.Material != null ? entrega.Material.Nombre : "",
            PesoKg = entrega.PesoKg,
            FechaEntrega = entrega.FechaEntrega
        };
    }

    public async Task Crear(CrearEntregaDto dto)
    {
        var entrega = new Entrega
        {
            UsuarioId = dto.UsuarioId,
            MaterialId = dto.MaterialId,
            PesoKg = dto.PesoKg,
            FechaEntrega = DateTime.Now
        };

        await _entregaRepository.Crear(entrega);
    }

    public async Task Actualizar(int id, CrearEntregaDto dto)
    {
        var entrega = await _entregaRepository.ObtenerPorId(id);

        if (entrega == null)
            return;

        entrega.UsuarioId = dto.UsuarioId;
        entrega.MaterialId = dto.MaterialId;
        entrega.PesoKg = dto.PesoKg;

        await _entregaRepository.Actualizar(entrega);
    }

    public async Task Eliminar(int id)
    {
        var entrega = await _entregaRepository.ObtenerPorId(id);

        if (entrega == null)
            return;

        await _entregaRepository.Eliminar(entrega);
    }
}