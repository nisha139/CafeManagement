using CafeManagement.Application.Persistence.Repositories.Base;
using CafeManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Persistence.Repositories.Base;
public class CommandRepository<T>(CafeDbContext context) : ICommandRepository<T> where T : BaseEntity, new()
{
#pragma warning disable CS9124 // Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.
    private readonly CafeDbContext _appDbContext = context;
#pragma warning restore CS9124 // Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.

    public async Task<T> AddAsync(T entity)
    {
        await _appDbContext.Set<T>().AddAsync(entity);
        return entity;
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _appDbContext.Set<T>().AddRangeAsync(entities);
    }

    public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        IQueryable<T> query = context.Set<T>();
        query = query.Where(e => e.Id == id);

#pragma warning disable CS8603 // Possible null reference return.
        return await query.AsNoTracking().SingleOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
    }

    public void Remove(T entity)
    {
        _appDbContext.Set<T>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _appDbContext.Set<T>().RemoveRange(entities);
    }

    public T Update(T entity)
    {
        _appDbContext.Set<T>().Update(entity);
        return entity;
    }

    public void Attach(T entity)
    {
        _appDbContext.Set<T>().Attach(entity);
    }
}

