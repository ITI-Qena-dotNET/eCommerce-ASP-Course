using eCommerce.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce_ASP_Course.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAllCategory()
    {
        return Ok(_context.Categories.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetCategoryById(int id)
    {
        return Ok(_context.Categories.Find(id));
    }
}
