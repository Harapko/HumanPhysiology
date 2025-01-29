using System;
using System.Linq;
using System.Linq.Expressions;

namespace HumPsi.Domain.Abstraction.IRepositories.@base;

public interface IRepositoryBase<T> where T : class
{
    IQueryable<T> GetAllAsync(Expression<Func<T, bool>>? predicate = null);
}