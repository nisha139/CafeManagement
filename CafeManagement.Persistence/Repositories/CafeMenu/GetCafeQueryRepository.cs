using Ardalis.Specification;
using CafeManagement.Application.Contracts.Responses;
using CafeManagement.Application.Features.CafeMenu.Dto;
using CafeManagement.Application.Models.Common;
using CafeManagement.Application.Persistence.Repositories.CafeMenu;
using CafeManagement.Persistence.Repositories.Base;
using CafeManagement.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Persistence.Repositories.CafeMenu;
public class GetCafeQueryRepository : QueryRepository<Domain.Entities.CafeMenu>, IGetCafeQueryRepository
{
    public GetCafeQueryRepository(CafeDbContext context) : base(context)
    {
    }

    public async Task<IPagedDataResponse<CafeMenuDto>> SearchAsync(ISpecification<CafeMenuDto> spec, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var cafeQuery = from cafe in context.CafeMenus.AsNoTracking()
                        select new CafeMenuDto
                        {
                            Id = cafe.Id,
                            Name = cafe.Name,
                            Price = cafe.Price,
                            Description = cafe.Description
                        };

        var pagedQuery = await cafeQuery.ApplySpecification(spec);
        var count = await cafeQuery.ApplySpecificationCount(spec);

        return new PagedApiResponse<CafeMenuDto>(count, pageNumber, pageSize) { Data = pagedQuery };
    }
}
