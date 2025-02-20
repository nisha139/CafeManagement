using CafeManagement.Application.Persistence.Base;
using CafeManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Persistence.Repositories.Base;
public class QueryRepository<T> : IQueryRepository<T> where T : BaseEntity, new()
{
    protected readonly CafeDbContext context;

    public QueryRepository(CafeDbContext context)
    {
        this.context = context;
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        var result = await context.Set<T>().Where(predicate).AnyAsync();
        return result;
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
    {
        var result = await context.Set<T>().Where(predicate).CountAsync();
        return result;
    }

    public async Task<IQueryable<T>> GetAllAsync(bool ignoreQueryFilters = false)
    {
        IQueryable<T> query = context.Set<T>();
        if (ignoreQueryFilters)
        {
            return query = query.IgnoreQueryFilters().AsNoTracking().AsQueryable();
        }
        else
        {
            return await Task.Run(() => query.AsNoTracking().AsQueryable());
        }
    }

    public async Task<IEnumerable<T>> GetAllWithIncludeAsync(Expression<Func<T, bool>>? predicate = null, bool ignoreQueryFilters = false, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = context.Set<T>();

        if (ignoreQueryFilters)
        {
            query = predicate is null ? query.IgnoreQueryFilters().AsNoTracking()
                                          : query.IgnoreQueryFilters().Where(predicate).AsNoTracking();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
        }
        else
        {
            query = predicate is null ? query.AsNoTracking()
                                          : query.Where(predicate).AsNoTracking();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
        }
        return await query.ToListAsync();

    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool ignoreQueryFilters = false)
    {
        IQueryable<T> query = context.Set<T>();
        if (ignoreQueryFilters)
        {
            query = query.IgnoreQueryFilters().Where(predicate).AsNoTracking();
        }
        else
        {
            query = query.Where(predicate).AsNoTracking();
        }

#pragma warning disable CS8603 // Possible null reference return.
        return await query.FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
    }

    public async Task<T> GetByIdAsync(string id, bool ignoreQueryFilters = false)
    {
        IQueryable<T> query = context.Set<T>();
        if (ignoreQueryFilters)
        {
            query = query.AsNoTracking().Where(e => e.Id == Guid.Parse(id)).IgnoreQueryFilters();
        }
        else
        {
            query = query.AsNoTracking().Where(e => e.Id == Guid.Parse(id));
        }

#pragma warning disable CS8603 // Possible null reference return.
        return await query.SingleOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
    }

    public async Task<T> GetWithIncludeAsync(Expression<Func<T, bool>> predicate, bool ignoreQueryFilters = false, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = context.Set<T>();
        if (ignoreQueryFilters)
        {
            query = query.IgnoreQueryFilters().Where(predicate).AsNoTracking();
            if (includes is not null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
        }
        else
        {
            query = query.Where(predicate).AsNoTracking();
            if (includes is not null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
        }

#pragma warning disable CS8603 // Possible null reference return.
        return await query.FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
    }
}