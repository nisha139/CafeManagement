using Ardalis.Specification;
using CafeManagement.Application.Contracts.Responses;
using CafeManagement.Application.Features.CafeMenu.Dto;
using CafeManagement.Application.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Application.Persistence.Repositories.CafeMenu;
public interface IGetCafeQueryRepository : IQueryRepository<Domain.Entities.CafeMenu>
{
    Task<IPagedDataResponse<CafeMenuDto>> SearchAsync(ISpecification<CafeMenuDto> spec, int pageNumber, int pageSize, CancellationToken cancellationToken);
}