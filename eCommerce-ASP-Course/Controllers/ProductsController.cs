using eCommerce.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce_ASP_Course.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        return Ok(_context.Products.ToList());
    }

    [HttpGet("Category/{categoryId}")]
    public IActionResult GetAllByCategoryId(int categoryId)
    {
        var productsResult = _context.Categories
            .Include(x => x.Products)
            .Where(x => x.ID == categoryId)
            .Select(x => x.Products)
            .ToList();

        return Ok(productsResult);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(_context.Products.Find(id));
    }
}
