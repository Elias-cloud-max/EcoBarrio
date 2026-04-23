namespace EcoBarrio.Application.DTOs;

public class EntregaDto
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public string UsuarioNombre { get; set; } = string.Empty;
    public int MaterialId { get; set; }
    public string MaterialNombre { get; set; } = string.Empty;
    public decimal PesoKg { get; set; }
    public DateTime FechaEntrega { get; set; }
}