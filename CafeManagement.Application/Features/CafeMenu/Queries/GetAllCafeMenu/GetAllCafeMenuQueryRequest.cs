using CafeManagement.Application.Contracts.Responses;
using CafeManagement.Application.Features.CafeMenu.Dto;
using CafeManagement.Application.Models.Specification.Filters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Application.Features.CafeMenu.Queries.GetAllCafeMenu;

public sealed class GetAllCafeMenuQueryRequest() : IRequest<IPagedDataResponse<CafeMenuDto>>
{
    public Guid id { get; set; }
    public PaginationFilter PaginationFilter { get; set; } = default!;
}
