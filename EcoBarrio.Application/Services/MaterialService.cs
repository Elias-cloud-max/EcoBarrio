using EcoBarrio.Application.Contracts;
using EcoBarrio.Application.DTOs;
using EcoBarrio.Domain.Entities;
using EcoBarrio.Infrastructure.Contracts;

namespace EcoBarrio.Application.Services;

public class MaterialService : IMaterialService
{
    private readonly IMaterialRepository _materialRepository;

    public MaterialService(IMaterialRepository materialRepository)
    {
        _materialRepository = materialRepository;
    }

    public async Task<List<MaterialDto>> ObtenerTodos()
    {
        var materiales = await _materialRepository.ObtenerTodos();

        return materiales.Select(m => new MaterialDto
        {
            Id = m.Id,
            Nombre = m.Nombre,
            Descripcion = m.Descripcion,
            CategoriaId = m.CategoriaId,
            CategoriaNombre = m.Categoria != null ? m.Categoria.Nombre : ""
        }).ToList();
    }

    public async Task<MaterialDto?> ObtenerPorId(int id)
    {
        var material = await _materialRepository.ObtenerPorId(id);

        if (material == null)
            return null;

        return new MaterialDto
        {
            Id = material.Id,
            Nombre = material.Nombre,
            Descripcion = material.Descripcion,
            CategoriaId = material.CategoriaId,
            CategoriaNombre = material.Categoria != null ? material.Categoria.Nombre : ""
        };
    }

    public async Task Crear(CrearMaterialDto dto)
    {
        var material = new Material
        {
            Nombre = dto.Nombre,
            Descripcion = dto.Descripcion,
            CategoriaId = dto.CategoriaId
        };

        await _materialRepository.Crear(material);
    }

    public async Task Actualizar(int id, CrearMaterialDto dto)
    {
        var material = await _materialRepository.ObtenerPorId(id);

        if (material == null)
            return;

        material.Nombre = dto.Nombre;
        material.Descripcion = dto.Descripcion;
        material.CategoriaId = dto.CategoriaId;

        await _materialRepository.Actualizar(material);
    }

    public async Task Eliminar(int id)
    {
        var material = await _materialRepository.ObtenerPorId(id);

        if (material == null)
            return;

        await _materialRepository.Eliminar(material);
    }
}