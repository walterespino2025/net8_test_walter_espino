using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Products.Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services) 
        {
            return services;
        }
    }
}
