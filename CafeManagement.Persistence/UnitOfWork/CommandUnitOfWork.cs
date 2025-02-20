using CafeManagement.Application.Persistence.Base;
using CafeManagement.Application.Persistence.UnitOfWork;
using CafeManagement.Domain.Common;
using CafeManagement.Persistence.Repositories.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Persistence.UnitOfWork;
public class CommandUnitOfWork : ICommandUnitOfWork
{
    private readonly CafeDbContext _appDbContext;
    private Hashtable _repositories;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public CommandUnitOfWork(CafeDbContext appDbContext)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        _appDbContext = appDbContext;
    }

    public async Task<int> SaveAsync(CancellationToken cancellationToken)
    {
        var result = await _appDbContext.SaveChangesAsync(cancellationToken);
        return result;
    }

    public ICommandRepository<TEntity> CommandRepository<TEntity>() where TEntity : BaseEntity, new()
    {
        if (_repositories == null) _repositories = new Hashtable();

        var type = typeof(TEntity).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(CommandRepository<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _appDbContext);

            _repositories.Add(type, repositoryInstance);
        }
        // Ensure _repositories[type] is not null before returning
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        return (ICommandRepository<TEntity>)_repositories[type] ?? new CommandRepository<TEntity>(_appDbContext);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
    }

    public void Dispose()
    {
        _appDbContext.Dispose();
    }
}
