using CafeManagement.Application.Features.CafeMenu.Dto;
using CafeManagement.Application.Models.Common;
using CafeManagement.Application.Persistence.Repositories.CafeMenu;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Application.Features.CafeMenu.Queries.GetAllCafeMenusQuery;
public sealed class GetAllCafeMenusQueryHandler : IRequestHandler<GetAllCafeMenusQueryRequest, ApiResponse<List<CafeMenuDto>>>
{
    private readonly IGetCafeQueryRepository _cafeMenuRepository;

    public GetAllCafeMenusQueryHandler(IGetCafeQueryRepository cafeMenuRepository)
    {
        _cafeMenuRepository = cafeMenuRepository;
    }

    public async Task<ApiResponse<List<CafeMenuDto>>> Handle(GetAllCafeMenusQueryRequest request, CancellationToken cancellationToken)
    {
        var cafeMenus = await _cafeMenuRepository.GetAllAsync();

        if (cafeMenus == null || !cafeMenus.Any())
        {
            return new ApiResponse<List<CafeMenuDto>>
            {
                Success = false,
                Message = "No cafe menus found",
                StatusCode = 404,
                Data = new List<CafeMenuDto>()
            };
        }

        var cafeMenuDtos = cafeMenus.Select(cafeMenu => new CafeMenuDto
        {
            Id = cafeMenu.Id,
            Name = cafeMenu.Name,
            Description = cafeMenu.Description,
            Price = cafeMenu.Price,
        }).ToList();

        return new ApiResponse<List<CafeMenuDto>>
        {
            Success = true,
            Message = "Cafe menus retrieved successfully",
            StatusCode = 200,
            Data = cafeMenuDtos
        };
    }
}