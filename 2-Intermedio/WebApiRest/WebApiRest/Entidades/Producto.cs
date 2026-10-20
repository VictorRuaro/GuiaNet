namespace WebApiRest.Entidades;

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public List<DetallePedido> Detalles { get; set; } = new();
}
