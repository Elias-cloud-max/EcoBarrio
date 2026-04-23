using EcoBarrio.Application.Contracts;
using EcoBarrio.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EcoBarrio.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EntregasController : ControllerBase
{
    private readonly IEntregaService _entregaService;

    public EntregasController(IEntregaService entregaService)
    {
        _entregaService = entregaService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        return Ok(await _entregaService.ObtenerTodos());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var entrega = await _entregaService.ObtenerPorId(id);

        if (entrega == null)
            return NotFound("Entrega no encontrada");

        return Ok(entrega);
    }

    [HttpPost]
    public async Task<IActionResult> Crear(CrearEntregaDto dto)
    {
        await _entregaService.Crear(dto);
        return Ok("Entrega registrada correctamente");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, CrearEntregaDto dto)
    {
        await _entregaService.Actualizar(id, dto);
        return Ok("Entrega actualizada correctamente");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        await _entregaService.Eliminar(id);
        return Ok("Entrega eliminada correctamente");
    }
}