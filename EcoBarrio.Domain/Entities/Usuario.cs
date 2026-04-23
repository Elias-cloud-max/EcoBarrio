namespace EcoBarrio.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;

    public ICollection<Entrega> Entregas { get; set; } = new List<Entrega>();
}