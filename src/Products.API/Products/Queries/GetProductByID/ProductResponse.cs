namespace Products.Application.Products.Queries.GetProductById;
public record ProductResponse(Guid Id, string Name, Double Price, int Stock);