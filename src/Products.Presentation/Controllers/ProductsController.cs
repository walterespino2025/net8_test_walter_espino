using Products.Application.Products.Commands.CreateProduct;
using Products.Application.Products.Queries.GetProductById;
using Products.Domain.Shared;
using Products.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Products.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class ProductsController : ApiController
{
    public ProductsController(ISender sender)
        : base(sender)
    {
    }

    [HttpPost]
    public async Task<IActionResult> RegisterProduct(CancellationToken cancellationToken)
    {
        var command = new CreateProductsCommand(
            
            "Walter");

        var result = await Sender.Send(command, cancellationToken);
        
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetProductByIdQuery(id);

        Result<ProductResponse> response = await Sender.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
    }
}