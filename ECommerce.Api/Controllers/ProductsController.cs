using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ECommerce.Application.Features.Products.Commands.CreateProduct;
using ECommerce.Application.Features.Products.Commands.UpdateProduct;
using ECommerce.Application.Features.Products.Commands.DeleteProduct;
using ECommerce.Application.Features.Products.Queries.GetAllProducts;
using ECommerce.Application.Features.Products.Queries.GetProductById;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // SOLO ADMIN PUEDE CREAR
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    // CUALQUIER USUARIO LOGUEADO
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllProductsQuery());
        return Ok(result);
    }

    // CUALQUIER USUARIO LOGUEADO
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetProductByIdQuery(id));

        return result is not null
            ? Ok(result)
            : NotFound();
    }

    // SOLO ADMIN PUEDE EDITAR
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductCommand command)
    {
        if (command.Id != Guid.Empty && id != command.Id)
            return BadRequest("El ID de la URL no coincide con el del body");

        var updatedCommand = command with { Id = id };

        var result = await _mediator.Send(updatedCommand);

        return result
            ? Ok("Producto actualizado correctamente")
            : NotFound();
    }

    // SOLO ADMIN PUEDE ELIMINAR
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteProductCommand(id));

        return result
            ? Ok("Producto eliminado correctamente")
            : NotFound();
    }
}