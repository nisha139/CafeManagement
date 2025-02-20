using CafeManagement.Application.Persistence.Base;
using CafeManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Application.Persistence.UnitOfWork;
public interface ICommandUnitOfWork : IDisposable
{
    ICommandRepository<TEntity> CommandRepository<TEntity>() where TEntity : BaseEntity, new();

    Task<int> SaveAsync(CancellationToken cancellationToken);
}