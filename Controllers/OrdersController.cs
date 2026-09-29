using EntrevistaApiNet8Errores.Data;
using EntrevistaApiNet8Errores.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntrevistaApiNet8Errores.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    // EJERCICIO 3:
    // Debe calcular Total = precio * cantidad y descontar el stock correcto.
    // Actualmente la logica produce resultados incorrectos.
    [HttpPost]
    public IActionResult Create(OrderRequest request)
    {
        var product = FakeDatabase.Products.FirstOrDefault(p => p.Id == request.ProductId);

        if (product is null)
            return NotFound("Producto no encontrado.");

        if (request.Quantity <= 0)
            return BadRequest("La cantidad debe ser mayor que cero.");

        if (product.Stock < request.Quantity)
            return BadRequest("Stock insuficiente.");

        var total = product.Price * request.Quantity; /*ERROR INTENCIONAL Solución: Estaba sumando en vez de multiplicar en el calculo*/ 
        product.Stock -= request.Quantity; /*ERROR INTENCIONAL Solución: Estaba restando en uno la cantidad del stock. Lo correcto es la cantidad que se solictia en la petición*/ 

        return Ok(new
        {
            Product = product.Name,
            Quantity = request.Quantity,
            Total = total,
            RemainingStock = product.Stock
        });
    }
}
