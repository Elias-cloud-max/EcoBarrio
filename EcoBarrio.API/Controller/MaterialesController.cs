using EcoBarrio.Application.Contracts;
using EcoBarrio.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EcoBarrio.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MaterialesController : ControllerBase
{
    private readonly IMaterialService _materialService;

    public MaterialesController(IMaterialService materialService)
    {
        _materialService = materialService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        return Ok(await _materialService.ObtenerTodos());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var material = await _materialService.ObtenerPorId(id);

        if (material == null)
            return NotFound("Material no encontrado");

        return Ok(material);
    }

    [HttpPost]
    public async Task<IActionResult> Crear(CrearMaterialDto dto)
    {
        await _materialService.Crear(dto);
        return Ok("Material creado correctamente");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, CrearMaterialDto dto)
    {
        await _materialService.Actualizar(id, dto);
        return Ok("Material actualizado correctamente");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        await _materialService.Eliminar(id);
        return Ok("Material eliminado correctamente");
    }
}