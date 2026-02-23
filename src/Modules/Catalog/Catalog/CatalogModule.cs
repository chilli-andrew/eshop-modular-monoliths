using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Data;

namespace Catalog;

public static class CatalogModule
{
    public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)
    {
        // will add dependencies
        
        // 1. add Api endpoint services
        
        // 2. add Application use case services
        
        // 3. add Data - infrastructure services
        var connectionString = configuration.GetConnectionString("Database");
        services.AddDbContext<CatalogDbContext>(options =>
            options.UseNpgsql(connectionString));
        
        return services;
    }

    public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
    {
        // will use dependencies
        
        // 1. use Api endpoint services
        
        // 2. use Application use case services
        
        // 3. use Data - infrastructure services
        app.UseMigration<CatalogDbContext>();
        return app;
    }
    
}