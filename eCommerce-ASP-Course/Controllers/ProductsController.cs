using eCommerce.Application.Features.Products.Commands.DeleteProduct;
using eCommerce.Application.Features.Products.Commands.InsertNewProduct;
using eCommerce.Application.Features.Products.Commands.PatchProduct;
using eCommerce.Application.Features.Products.Commands.UpdateProduct;
using eCommerce.Application.Features.Products.DTOs;
using eCommerce.Application.Features.Products.Queries.GetAllProducts;
using eCommerce.Application.Features.Products.Queries.GetProductById;
using eCommerce.Domain.Entities;
using eCommerce.Infrastructure.Data;
using Mediator;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce_ASP_Course.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMediator _mediator;

    public ProductsController(AppDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts(CancellationToken ct)
    {
        return Ok(await _mediator.Send(new GetAllProductsQuery(), ct));
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
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        return Ok(await _mediator.Send(new GetProductByIdQuery { ID = id }, ct));
    }

    [HttpPost]
    public async Task<IActionResult> InsertNewProduct(InsertNewProductDTO command, CancellationToken ct)
    {
        return Ok(await _mediator.Send(new InsertNewProductCommand(command), ct));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductDTO command, CancellationToken ct)
    {
        var res = await _mediator.Send(new UpdateProductCommand(command), ct);

        if (res is null)
            return NotFound();

        return Ok(res);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchProduct(Guid id, JsonPatchDocument<Product> commandUpdates, CancellationToken ct)
    {
        var result = await _mediator.Send(new PatchProductCommand() { ID = id, PatchUpdates = commandUpdates }, ct);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id, CancellationToken ct)
    {
        await _mediator.Send(new DeleteProductCommand() { ID = id }, ct);
        return NoContent();
    }
}
