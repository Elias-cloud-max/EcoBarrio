using EcoBarrio.Application.Contracts;
using EcoBarrio.Application.DTOs;
using EcoBarrio.Domain.Entities;
using EcoBarrio.Infrastructure.Contracts;

namespace EcoBarrio.Application.Services;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaService(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public async Task<List<CategoriaDto>> ObtenerTodos()
    {
        var categorias = await _categoriaRepository.ObtenerTodos();

        return categorias.Select(c => new CategoriaDto
        {
            Id = c.Id,
            Nombre = c.Nombre,
            Descripcion = c.Descripcion
        }).ToList();
    }

    public async Task<CategoriaDto?> ObtenerPorId(int id)
    {
        var categoria = await _categoriaRepository.ObtenerPorId(id);

        if (categoria == null)
            return null;

        return new CategoriaDto
        {
            Id = categoria.Id,
            Nombre = categoria.Nombre,
            Descripcion = categoria.Descripcion
        };
    }

    public async Task Crear(CrearCategoriaDto dto)
    {
        var categoria = new Categoria
        {
            Nombre = dto.Nombre,
            Descripcion = dto.Descripcion
        };

        await _categoriaRepository.Crear(categoria);
    }

    public async Task Actualizar(int id, CrearCategoriaDto dto)
    {
        var categoria = await _categoriaRepository.ObtenerPorId(id);

        if (categoria == null)
            return;

        categoria.Nombre = dto.Nombre;
        categoria.Descripcion = dto.Descripcion;

        await _categoriaRepository.Actualizar(categoria);
    }

    public async Task Eliminar(int id)
    {
        var categoria = await _categoriaRepository.ObtenerPorId(id);

        if (categoria == null)
            return;

        await _categoriaRepository.Eliminar(categoria);
    }
}