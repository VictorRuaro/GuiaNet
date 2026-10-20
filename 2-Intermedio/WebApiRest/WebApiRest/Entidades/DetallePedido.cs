namespace WebApiRest.Entidades;
public class DetallePedido
{
    public int Id { get; set; }

    // Relación con Pedido
    public int PedidoId { get; set; }
    public Pedido Pedido { get; set; } = null!;

    // Relación con Producto
    public int ProductoId { get; set; }
    public Producto Producto { get; set; } = null!;

    // Propiedades adicionales esenciales del negocio
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
}
