using CafeManagement.Application.Features.CafeMenu.Dto;
using MediatR;

namespace CafeManagement.Application.Features.CafeMenu.Command.UpdateCafeMenu;
public class UpdateCafeMenuCommandRequest : IRequest<CafeMenuDto>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
}


