using EntrevistaApiNet8Errores.Data;
using Microsoft.AspNetCore.Mvc;

namespace EntrevistaApiNet8Errores.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    // EJERCICIO 1:
    // Este endpoint compila y responde, pero tiene un error de logica.
    // GET /api/products/2 deberia devolver el producto con Id = 2.
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var product = FakeDatabase.Products.FirstOrDefault(p => p.Id != id); // ERROR INTENCIONAL

        if (product is null)
            return NotFound();

        return Ok(product);
    }
}
