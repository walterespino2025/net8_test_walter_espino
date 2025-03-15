using MediatR;

namespace Products.Application;

public static class AssemblyReference
{
    public static readonly IMediator Assembly = typeof(AssemblyReference).Assembly;
}