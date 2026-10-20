namespace WebApiRest.Entidades;

public class Pedido
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; } = DateTime.UtcNow;
    public decimal Total { get; set; }

    // Clave foránea y propiedad de navegación hacia Cliente
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; } = null!;

    public List<DetallePedido> Detalles { get; set; } = new();
}
