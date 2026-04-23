using EcoBarrio.Application.Contracts;
using EcoBarrio.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EcoBarrio.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuariosController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var usuarios = await _usuarioService.ObtenerTodos();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var usuario = await _usuarioService.ObtenerPorId(id);

        if (usuario == null)
            return NotFound("Usuario no encontrado");

        return Ok(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Crear(CrearUsuarioDto dto)
    {
        await _usuarioService.Crear(dto);
        return Ok("Usuario creado correctamente");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, CrearUsuarioDto dto)
    {
        await _usuarioService.Actualizar(id, dto);
        return Ok("Usuario actualizado correctamente");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        await _usuarioService.Eliminar(id);
        return Ok("Usuario eliminado correctamente");
    }
}