using EntrevistaApiNet8Errores.Data;
using EntrevistaApiNet8Errores.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntrevistaApiNet8Errores.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    // EJERCICIO 2:
    // La validacion de correo esta invertida.
    // Un correo valido como candidato@empresa.com NO deberia ser rechazado.
    [HttpPost]
    public IActionResult Create(Customer customer)
    {
        if (string.IsNullOrWhiteSpace(customer.Name))
            return BadRequest("El nombre es obligatorio.");

        if (!customer.Email.Contains("@")) /*ERROR INTENCIONAL Solución: La validación estaba diciendo que si tiene una arroba el correo no es válido. Se agregó un "!" para negar la expresión*/ 
            return BadRequest("El correo no tiene un formato valido.");

        customer.Id = FakeDatabase.Customers.Max(c => c.Id) + 1;
        FakeDatabase.Customers.Add(customer);

        return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var customer = FakeDatabase.Customers.FirstOrDefault(c => c.Id == id);
        return customer is null ? NotFound() : Ok(customer);
    }
}
