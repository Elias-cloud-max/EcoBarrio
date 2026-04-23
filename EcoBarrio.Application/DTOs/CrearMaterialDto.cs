namespace EcoBarrio.Application.DTOs;

public class CrearMaterialDto
{
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public int CategoriaId { get; set; }
}