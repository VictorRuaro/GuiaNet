namespace WebApiRest.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApiRest.Servicios;

public record ProductoDto(string Nombre, decimal Precio);
public record ClienteDto(string Nombre, string Email);
public record ItemPedidoDto(int ProductoId, int Cantidad);
public record PedidoDto(int ClienteId, List<ItemPedidoDto> Items);
public record FiltrosDto(DateTime Fecha, int ClienteId);


[ApiController]
[Route("api/[controller]")]
public class TiendaController : ControllerBase
{
    private readonly TiendaService _tiendaService;

    // Inyección del servicio
    public TiendaController(TiendaService tiendaService)
    {
        _tiendaService = tiendaService;
    }

    [HttpPost("productos")]
    public async Task<IActionResult> CrearProducto([FromBody] ProductoDto dto)
    {
        var producto = await _tiendaService.RegistrarProductoAsync(dto.Nombre, dto.Precio);
        return Ok(producto);
    }

    [HttpPost("clientes")]
    public async Task<IActionResult> CrearCliente([FromBody] ClienteDto dto)
    {
        var cliente = await _tiendaService.RegistrarClienteAsync(dto.Nombre, dto.Email);
        return Ok(cliente);
    }

    [HttpPost("pedidos")]
    public async Task<IActionResult> CrearPedido([FromBody] PedidoDto dto)
    {
        try
        {
            // Convertimos la lista del DTO al formato de tuplas que espera el servicio
            var items = dto.Items.Select(i => (i.ProductoId, i.Cantidad)).ToList();

            var pedido = await _tiendaService.GenerarPedidoAsync(dto.ClienteId, items);
            return Ok(pedido);
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
    }

    [HttpPost("Resumen")]
    public async Task<IActionResult> CrearPedido([FromBody] FiltrosDto dto)
    {
        try
        {

            var pedido = await _tiendaService.ObtenerPedidosAsync(dto.Fecha, dto.ClienteId);
            return Ok(pedido);
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
    }
}

