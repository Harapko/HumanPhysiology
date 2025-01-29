using FluentValidation;
using HumPsi.Application.Behaviours;
using HumPsi.Domain;
using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Abstraction.IRepositories.@base;
using HumPsi.Infrastructure.Factory;
using HumPsi.Infrastructure.Realizations.Repositories;
using HumPsi.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.OpenApi.Models;

namespace HumPsi.Api.Extensions;

public static class ServiceCollectionExtensions
{
    private static void AddRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
    }

    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddRepositoryServices();
        services.AddScoped<IRedisRepository, RedisRepository>();
        services.AddScoped<ISectionRepository, SectionRepository>();
        services.AddScoped<IHeadlineRepository, HeadlineRepository>();
        services.AddScoped<IPhotoRepository, PhotoRepository>();
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<ISqlConnFactory, SqlConnFactory>();
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        var currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();
        services.AddAutoMapper(currentAssemblies);
        services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));

    }
    
    public static void AddApplicationServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        var redisConnStr = configuration.GetConnectionString(nameof(RedisCache));
        
        services.AddDbContext<HumPsiDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString(nameof(HumPsiDbContext))));

        services.AddStackExchangeRedisCache(options =>
            options.Configuration = redisConnStr);
    }
    
    public static void AddSwaggerServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyApi", Version = "v1" });
            opt.CustomSchemaIds(x => x.FullName);
        });
    }


    
}