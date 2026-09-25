# Entrevista .NET 8 - 3 ejercicios con errores intencionales

Proyecto de practica para entrevista tecnica. La API esta hecha en C# con ASP.NET Core .NET 8 y Docker.

**Importante:** el proyecto contiene errores intencionales de logica. La API debe compilar y arrancar, pero algunos endpoints entregan resultados incorrectos. El objetivo del candidato es localizar y corregir los problemas.

## Ejecutar con Docker

Desde esta carpeta:

```bash
docker compose up --build -d
```

Swagger:

```text
http://localhost:8080/swagger
```

Para detener:

```bash
docker compose down
```

## Ejercicio 1 - Obtener producto por ID

Endpoint:

```text
GET http://localhost:8080/api/products/2
```

### Comportamiento esperado

Debe regresar exactamente el producto con `Id = 2`:

```json
{
  "id": 2,
  "name": "Sudadera",
  "price": 900,
  "stock": 5
}
```

También debe regresar `404 Not Found` si se solicita un ID inexistente, por ejemplo:

```text
GET http://localhost:8080/api/products/999
```

### Tarea

Encontrar por que el endpoint devuelve un producto equivocado y corregirlo.

---

## Ejercicio 2 - Registrar cliente

Endpoint:

```text
POST http://localhost:8080/api/customers
Content-Type: application/json
```

Body:

```json
{
  "name": "Emmanuel Morales",
  "email": "emmanuel@empresa.com"
}
```

### Comportamiento esperado

Un correo valido debe permitir crear el cliente y responder `201 Created`.

Un correo evidentemente invalido, por ejemplo:

```json
{
  "name": "Usuario Prueba",
  "email": "correo-invalido"
}
```

debe responder `400 Bad Request`.

### Tarea

Encontrar por que la validacion esta funcionando al reves y corregirla.

---

## Ejercicio 3 - Crear pedido

Endpoint:

```text
POST http://localhost:8080/api/orders
Content-Type: application/json
```

Body:

```json
{
  "productId": 1,
  "quantity": 2
}
```

El producto 1 cuesta `$350` y tiene stock inicial de `10`.

### Comportamiento esperado

Para cantidad 2:

```json
{
  "product": "Playera",
  "quantity": 2,
  "total": 700,
  "remainingStock": 8
}
```

### Tarea

Corregir:

- El calculo del total.
- El descuento de inventario.
- Mantener las validaciones de cantidad y stock.

## Reglas sugeridas para la entrevista

1. No reemplazar los endpoints completos sin explicar el problema.
2. Identificar primero la causa del error.
3. Corregir el codigo.
4. Reconstruir el contenedor.
5. Comprobar el resultado desde Postman.
6. Explicar que codigo se cambio y por que.

## Reconstruir despues de modificar codigo

```bash
docker compose down
docker compose up --build -d
```

## Ver logs

```bash
docker compose logs -f api
```
