using Products.Domain.Shared;
using MediatR;

namespace Products.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}