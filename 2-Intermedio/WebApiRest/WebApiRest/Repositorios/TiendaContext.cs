using Microsoft.EntityFrameworkCore;
using WebApiRest.Entidades;

namespace WebApiRest.Repositorios;

public class TiendaContext : DbContext
{
    // ESTE CONSTRUCTOR ES OBLIGATORIO PARA QUE FUNCIONE LA INYECCIÓN DESDE PROGRAM.CS
    public TiendaContext(DbContextOptions<TiendaContext> options) : base(options)
    {
    }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }

    // Nueva tabla intermedia:
    public DbSet<DetallePedido> DetallesPedidos { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    // Define la cadena de conexión apuntando a un archivo local
    //    optionsBuilder.UseSqlite("Data Source=tienda.db");
    //}
}
