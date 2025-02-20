using CafeManagement.Application.Persistence.Repositories.Base;
using CafeManagement.Application.Persistence.Repositories.CafeMenu;
using CafeManagement.Domain.Common;

namespace CafeManagement.Application.Persistence.UnitOfWork;
public interface IQueryUnitOfWork : IDisposable
{
    IGetCafeQueryRepository getCafeQueryRepository { get; }
    IQueryRepository<TEntity> QueryRepository<TEntity>() where TEntity : BaseEntity, new();
}
