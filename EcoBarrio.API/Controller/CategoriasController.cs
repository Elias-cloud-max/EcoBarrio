using EcoBarrio.Application.Contracts;
using EcoBarrio.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EcoBarrio.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;

    public CategoriasController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        return Ok(await _categoriaService.ObtenerTodos());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var categoria = await _categoriaService.ObtenerPorId(id);

        if (categoria == null)
            return NotFound("Categoría no encontrada");

        return Ok(categoria);
    }

    [HttpPost]
    public async Task<IActionResult> Crear(CrearCategoriaDto dto)
    {
        await _categoriaService.Crear(dto);
        return Ok("Categoría creada correctamente");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, CrearCategoriaDto dto)
    {
        await _categoriaService.Actualizar(id, dto);
        return Ok("Categoría actualizada correctamente");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        await _categoriaService.Eliminar(id);
        return Ok("Categoría eliminada correctamente");
    }
}