using System;
using System.Linq;
using System.Linq.Expressions;
using HumPsi.Domain;
using HumPsi.Domain.Abstraction.IRepositories.@base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace HumPsi.Infrastructure.Repositories;

public class RepositoryBase<T> 
    (HumPsiDbContext context) : IRepositoryBase<T> where T : class
{
    public IQueryable<T> GetAllAsync(Expression<Func<T, bool>>? predicate = null)
    {
        if (predicate is null)
            return context
                .Set<T>()
                .AsNoTracking();
        
        return context
            .Set<T>()
            .Where(predicate)
            .AsNoTracking();
    }

    private IQueryable<T> GetQueryable(
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Expression<Func<T, T>>? selector = null)
    {
        var query = context
            .Set<T>()
            .AsNoTracking();

        if (include is not null)
        {
            query = include(query);
        }
        
        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        if (selector is not null)
        {
            query = query.Select(selector);
        }
        return query
            .AsNoTracking();
    }
}