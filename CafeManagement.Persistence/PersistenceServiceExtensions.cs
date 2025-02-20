using CafeManagement.Application.Persistence.Repositories.CafeMenu;
using CafeManagement.Application.Persistence.UnitOfWork;
using CafeManagement.Persistence.Repositories.CafeMenu;
using CafeManagement.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CafeManagement.Persistence;
public static class PersistenceServiceExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CafeDbContext>((sp, options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<ICommandUnitOfWork, CommandUnitOfWork>();
        services.AddScoped<IQueryUnitOfWork, QueryUnitOfWork>();
        services.AddScoped<IGetCafeQueryRepository, GetCafeQueryRepository>();

        return services;
    }
}
