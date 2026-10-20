using HardenACrud.Models;
using HardenCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace HardenACrud.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static readonly List<Product> Products = new()
    {
        new Product { Id = 1, Name = "Mouse", Price = 599 },
        new Product { Id = 2, Name = "Keyboard", Price = 899 }
    };

    // GET: api/products
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll()
    {
        return Ok(Products);
    }

    // GET: api/products/1
    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);

        if (product == null)
            return NotFound();

        return Ok(product);
    }

    // POST: api/products
    [HttpPost]
    public ActionResult<Product> Create(CreateProductRequest request)
    {
        var product = new Product
        {
            Id = Products.Count == 0 ? 1 : Products.Max(p => p.Id) + 1,
            Name = request.Name,
            Price = request.Price
        };

        Products.Add(product);

        return CreatedAtAction(
            nameof(GetById),
            new { id = product.Id },
            product);
    }

    // PUT: api/products/1
    [HttpPut("{id}")]
    public ActionResult<Product> Update(
        int id, UpdateProductRequest request)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);

        if (product == null)
            return NotFound();

        product.Name = request.Name;
        product.Price = request.Price;

        return Ok(product);
    }

    // DELETE: api/products/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);

        if (product == null)
            return NotFound();

        Products.Remove(product);

        return NoContent();
    }
}
