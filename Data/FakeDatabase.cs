using EntrevistaApiNet8Errores.Models;

namespace EntrevistaApiNet8Errores.Data;

public static class FakeDatabase
{
    public static List<Product> Products { get; } = new()
    {
        new Product { Id = 1, Name = "Playera", Price = 350m, Stock = 10 },
        new Product { Id = 2, Name = "Sudadera", Price = 900m, Stock = 5 },
        new Product { Id = 3, Name = "Pantalon", Price = 650m, Stock = 8 }
    };

    public static List<Customer> Customers { get; } = new()
    {
        new Customer { Id = 1, Name = "Cliente Inicial", Email = "cliente@demo.com" }
    };
}
