using eCommerce.Domain.Entities;
using eCommerce.Infrastructure.Data;
using eCommerce_ASP_Course.Models;
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

    [HttpPost]
    public IActionResult AddCategory(CategoryDto dto)
    {
        var newCategory = new Category
        {
            ID = dto.ID,
            Name = dto.Name
        };

        _context.Categories.Add(newCategory);
        _context.SaveChanges();

        return Ok(newCategory);
    }

    [HttpPut]
    public IActionResult UpdateCategory(CategoryDto dto) 
    {
        var newCategory = new Category
        {
            ID = dto.ID,
            Name = dto.Name
        };

        _context.Categories.Update(newCategory);
        _context.SaveChanges();

        return Ok(newCategory);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id) 
    { 
        var category = _context.Categories.Find(id);

        if (category is null) 
        {
            return NotFound();
        }

        _context.Categories.Remove(category);
        _context.SaveChanges();

        return NoContent();
    }
}
