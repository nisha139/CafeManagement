using CafeManagement.Application.Features.CafeMenu.Dto;
using MediatR;

namespace CafeManagement.Application.Features.CafeMenu.Command.CreateCafeMenu;
public class CreateCafeMenuCommandRequest : IRequest<CafeMenuDto>
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
}

