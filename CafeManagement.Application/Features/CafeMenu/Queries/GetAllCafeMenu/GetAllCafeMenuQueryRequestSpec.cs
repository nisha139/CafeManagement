using Ardalis.Specification;
using CafeManagement.Application.Contracts.Responses;
using CafeManagement.Application.Features.CafeMenu.Dto;
using CafeManagement.Application.Models.Specification;
using CafeManagement.Application.Models.Specification.Filters;
using CafeManagement.Application.Persistence.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CafeManagement.Application.Features.CafeMenu.Queries.GetAllCafeMenu;

internal class GetAllCafeMenuQueryRequestSpec : EntitiesByPaginationFilterSpec<CafeMenuDto>
{
    public GetAllCafeMenuQueryRequestSpec(GetAllCafeMenuQueryRequest request)
        : base(request.PaginationFilter) =>
        Query.OrderByDescending(c => c.Name, !request.PaginationFilter.HasOrderBy());
}
public class GetAllCafeMenuQueryRequestSpecQueryHandler(IQueryUnitOfWork query) : IRequestHandler<GetAllCafeMenuQueryRequest, IPagedDataResponse<CafeMenuDto>>
{
    private readonly IQueryUnitOfWork _query = query;
    public async Task<IPagedDataResponse<CafeMenuDto>> Handle(GetAllCafeMenuQueryRequest request, CancellationToken cancellationToken)
    {
        var spec = new GetAllCafeMenuQueryRequestSpec(request);
        return await _query.getCafeQueryRepository.SearchAsync(spec, request.PaginationFilter.PageNumber, request.PaginationFilter.PageSize, cancellationToken);
    }
}