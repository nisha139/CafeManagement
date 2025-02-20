using CafeManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Application.Persistence.Base;
public interface IQueryRepository<T> where T : BaseEntity, new()
{
    Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    Task<IQueryable<T>> GetAllAsync(bool ignoreQueryFilters = false);
    Task<IEnumerable<T>> GetAllWithIncludeAsync(Expression<Func<T, bool>>? predicate = null, bool ignoreQueryFilters = false, params Expression<Func<T, object>>[] includes);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool ignoreQueryFilters = false);
    Task<T> GetByIdAsync(string id, bool ignoreQueryFilters = false);
    Task<T> GetWithIncludeAsync(Expression<Func<T, bool>> predicate, bool ignoreQueryFilters = false, params Expression<Func<T, object>>[] includes);
}
