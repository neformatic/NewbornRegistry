using Microsoft.EntityFrameworkCore;
using NewbornRegistry.BLL.Services;
using NewbornRegistry.BLL.Services.Interfaces;
using NewbornRegistry.Common.Constants;
using NewbornRegistry.DAL;
using NewbornRegistry.DAL.Repositories;
using NewbornRegistry.DAL.Repositories.Interfaces;

namespace NewbornRegistry.API.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddDependencyInjection(this IServiceCollection services,
        IConfiguration configuration)
    {
        InitDatabaseContexts(services, configuration);
        InitApiServices(services);
        InitBllServices(services);
        InitDalServices(services);
    }

    private static void InitDatabaseContexts(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(AppSettingsNameConstants.NewbornRegistryConnectionStringName);

        services.AddDbContext<NewbornRegistryDbContext>(config =>
        {
            config.UseNpgsql(connectionString);
        });
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    private static void InitApiServices(IServiceCollection services)
    {
    }

    private static void InitBllServices(IServiceCollection services)
    {
        services.AddScoped<IPatientService, PatientService>();
    }

    private static void InitDalServices(IServiceCollection services)
    {
        services.AddScoped<IPatientRepository, PatientRepository>();
    }
}