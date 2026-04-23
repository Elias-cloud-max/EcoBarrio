namespace EcoBarrio.Domain.Entities;

public class Entrega
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; } = null!;

    public int MaterialId { get; set; }
    public Material Material { get; set; } = null!;

    public decimal PesoKg { get; set; }
    public DateTime FechaEntrega { get; set; } = DateTime.Now;
}