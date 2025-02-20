using CafeManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Application.Persistence.Base;
public interface ICommandRepository<T> where T : BaseEntity, new()
{
    Task<T> AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    T Update(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    void Attach(T entity);
}


