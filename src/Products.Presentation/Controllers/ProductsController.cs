using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Products.Commands.CreateProduct;
using Products.Application.Products.Commands.DeleteProduct;
using Products.Application.Products.Queries.GetAllProducts;
using Products.Application.Products.Queries.GetProductById;
using Products.Domain.Shared;
using Products.Presentation.Abstractions;

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
    public async Task<IActionResult> RegisterProduct(CreateProductsCommand command, CancellationToken cancellationToken)
    {
        

        var result = await Sender.Send(command, cancellationToken);


        return result!=Guid.Empty ? Ok(result + " " + command) : BadRequest(result == Guid.Empty);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetProductByIdQuery(id);

        Result<ProductResponse> response = await Sender.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
    }

    [HttpGet()]
    public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
    {
        var query = new GetAllProductsQuery();

        Result<List<AllProductResponse>> response = await Sender.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteProductCommand(id);

        var response = await Sender.Send(command, cancellationToken);

        return response != Guid.Empty ? Ok("Record "+ id + " deleted") : NotFound(id);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductsCommand command, CancellationToken cancellationToken)
    {


        var result = await Sender.Send(command, cancellationToken);


        return result != Guid.Empty ? Ok(result + " " + command) : BadRequest(result == Guid.Empty);
    }
}