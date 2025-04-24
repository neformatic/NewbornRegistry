using FluentValidation;
using FluentValidation.AspNetCore;
using NewbornRegistry.BLL;

namespace NewbornRegistry.API.Infrastructure;

public static class FluentValidationStartupExtension
{
    public static void AddFluentValidationConfiguration(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<Program>();
        services.AddValidatorsFromAssemblyContaining(typeof(BllAssemblyReference));
    }
}