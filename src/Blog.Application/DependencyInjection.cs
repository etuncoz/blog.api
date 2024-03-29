using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace Blog.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));
        });

        services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection));
        
        return services;
    }
}