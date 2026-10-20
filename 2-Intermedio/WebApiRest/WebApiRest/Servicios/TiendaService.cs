namespace WebApiRest.Servicios;
using Microsoft.EntityFrameworkCore;
using WebApiRest.Entidades;
using WebApiRest.Repositorios;

public class TiendaService
{
    private readonly TiendaContext _db;

    // El contenedor de dependencias pasará el DbContext de forma automática aquí
    public TiendaService(TiendaContext db)
    {
        _db = db;
    }

    public async Task<Producto> RegistrarProductoAsync(string nombre, decimal precio)
    {
        var nuevoProducto = new Producto { Nombre = nombre, Precio = precio };
        _db.Productos.Add(nuevoProducto);
        await _db.SaveChangesAsync();
        return nuevoProducto;
    }

    public async Task<Cliente> RegistrarClienteAsync(string nombre, string email)
    {
        var nuevoCliente = new Cliente { Nombre = nombre, Email = email };
        _db.Clientes.Add(nuevoCliente);
        await _db.SaveChangesAsync();
        return nuevoCliente;
    }

    public async Task<Pedido> GenerarPedidoAsync(int clienteId, List<(int ProductoId, int Cantidad)> itemsPedido)
    {
        using var transaccion = await _db.Database.BeginTransactionAsync();
        try
        {
            var clienteExiste = await _db.Clientes.AnyAsync(c => c.Id == clienteId);
            if (!clienteExiste) throw new Exception($"El cliente con ID {clienteId} no existe.");

            var nuevoPedido = new Pedido { ClienteId = clienteId, Fecha = DateTime.UtcNow, Total = 0 };
            decimal totalPedido = 0;

            foreach (var item in itemsPedido)
            {
                var producto = await _db.Productos.FindAsync(item.ProductoId);
                if (producto == null) throw new Exception($"El producto con ID {item.ProductoId} no existe.");

                var detalle = new DetallePedido
                {
                    ProductoId = item.ProductoId,
                    Cantidad = item.Cantidad,
                    PrecioUnitario = producto.Precio
                };

                totalPedido += (producto.Precio * item.Cantidad);
                nuevoPedido.Detalles.Add(detalle);
            }

            nuevoPedido.Total = totalPedido;
            _db.Pedidos.Add(nuevoPedido);
            await _db.SaveChangesAsync();
            await transaccion.CommitAsync();

            return nuevoPedido;
        }
        catch (Exception)
        {
            await transaccion.RollbackAsync();
            throw;
        }
    }

    public async Task<List<Pedido>> ObtenerPedidosAsync(DateTime fecha, int clienteId)
    {
        return await _db.Pedidos
            .Where(p => p.Fecha.Date >= fecha.Date && p.Fecha.Date <= fecha.Date
            && p.ClienteId==clienteId
        ).ToListAsync() ;
    }
}


