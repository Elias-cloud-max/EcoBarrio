namespace EcoBarrio.Domain.Entities;

public class Material
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;

    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; } = null!;

    public ICollection<Entrega> Entregas { get; set; } = new List<Entrega>();
}