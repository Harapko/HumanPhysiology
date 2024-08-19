using FluentValidation;
using HumPsi.Domain;
using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HumPsi.Infrastructure;

public static  class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var redisConnStr = configuration.GetConnectionString(nameof(RedisCache));
        
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString(nameof(AppDbContext))));

        services.AddMediatR(config => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddStackExchangeRedisCache(options =>
            options.Configuration = redisConnStr);

        services.AddScoped<ISectionRepository, SectionRepository>();
        
        return services;
    }
}