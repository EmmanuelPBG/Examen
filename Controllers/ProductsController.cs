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
        var product = FakeDatabase.Products.FirstOrDefault(p => p.Id == id); /* ERROR INTENCIONAL. Solución: Dentro de la expresión el Id de la FakeDatabase no estaba tomando el id correcto del get por el != 
        'que no sea igual' mejor == para igualar al id correcto*/
        if (product is null)
            return NotFound();

        return Ok(product);
    }
}
