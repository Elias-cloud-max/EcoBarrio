using EcoBarrio.Application.Contracts;
using EcoBarrio.Application.DTOs;
using EcoBarrio.Domain.Entities;
using EcoBarrio.Infrastructure.Contracts;

namespace EcoBarrio.Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<List<UsuarioDto>> ObtenerTodos()
    {
        var usuarios = await _usuarioRepository.ObtenerTodos();

        return usuarios.Select(u => new UsuarioDto
        {
            Id = u.Id,
            Nombre = u.Nombre,
            Telefono = u.Telefono,
            Direccion = u.Direccion
        }).ToList();
    }

    public async Task<UsuarioDto?> ObtenerPorId(int id)
    {
        var usuario = await _usuarioRepository.ObtenerPorId(id);

        if (usuario == null)
            return null;

        return new UsuarioDto
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            Telefono = usuario.Telefono,
            Direccion = usuario.Direccion
        };
    }

    public async Task Crear(CrearUsuarioDto dto)
    {
        var usuario = new Usuario
        {
            Nombre = dto.Nombre,
            Telefono = dto.Telefono,
            Direccion = dto.Direccion
        };

        await _usuarioRepository.Crear(usuario);
    }

    public async Task Actualizar(int id, CrearUsuarioDto dto)
    {
        var usuario = await _usuarioRepository.ObtenerPorId(id);

        if (usuario == null)
            return;

        usuario.Nombre = dto.Nombre;
        usuario.Telefono = dto.Telefono;
        usuario.Direccion = dto.Direccion;

        await _usuarioRepository.Actualizar(usuario);
    }

    public async Task Eliminar(int id)
    {
        var usuario = await _usuarioRepository.ObtenerPorId(id);

        if (usuario == null)
            return;

        await _usuarioRepository.Eliminar(usuario);
    }
}