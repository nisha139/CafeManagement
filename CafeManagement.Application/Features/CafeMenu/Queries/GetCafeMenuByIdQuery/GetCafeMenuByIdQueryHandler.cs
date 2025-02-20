using CafeManagement.Application.Features.CafeMenu.Dto;
using CafeManagement.Application.Models.Common;
using CafeManagement.Application.Persistence.Repositories.CafeMenu;
using MediatR;

namespace CafeManagement.Application.Features.CafeMenu.Queries.GetCafeMenuByIdQuery;
public sealed class GetCafeMenuByIdQueryHandler : IRequestHandler<GetCafeMenuByIdQueryRequest, ApiResponse<CafeMenuDto>>
{
    private readonly IGetCafeQueryRepository _cafeMenuRepository;

    public GetCafeMenuByIdQueryHandler(IGetCafeQueryRepository cafeMenuRepository)
    {
        _cafeMenuRepository = cafeMenuRepository;
    }

    public async Task<ApiResponse<CafeMenuDto>> Handle(GetCafeMenuByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var cafeMenu = await _cafeMenuRepository.GetByIdAsync(request.Id.ToString());

        if (cafeMenu == null)
        {
            return new ApiResponse<CafeMenuDto>
            {
                Success = false,
                Message = "Cafe menu not found",
                StatusCode = 404,
                Data = null
            };
        }

        var cafeMenuDto = new CafeMenuDto
        {
            Id = cafeMenu.Id,
            Name = cafeMenu.Name,
            Description = cafeMenu.Description,
            Price = cafeMenu.Price,
        };

        return new ApiResponse<CafeMenuDto>
        {
            Success = true,
            Message = "Cafe menu retrieved successfully",
            StatusCode = 200,
            Data = cafeMenuDto
        };
    }
}
