using CafeManagement.Application.Features.CafeMenu.Dto;
using CafeManagement.Application.Persistence.UnitOfWork;
using MediatR;

namespace CafeManagement.Application.Features.CafeMenu.Command.CreateCafeMenu;
public class CreateCafeMenuHandler : IRequestHandler<CreateCafeMenuCommandRequest, CafeMenuDto>
{
    private readonly ICommandUnitOfWork _unitOfWork;

    public CreateCafeMenuHandler(ICommandUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CafeMenuDto> Handle(CreateCafeMenuCommandRequest request, CancellationToken cancellationToken)
    {
        var cafeMenu = new Domain.Entities.CafeMenu
        {
            Name = request.Name,
            Price = request.Price,
            Description = request.Description
        };

        var addedEntity = await _unitOfWork.CommandRepository<Domain.Entities.CafeMenu>().AddAsync(cafeMenu);

        await _unitOfWork.SaveAsync(cancellationToken);

        return new CafeMenuDto
        {
            Id = addedEntity.Id,
            Name = addedEntity.Name,
            Price = addedEntity.Price,
            Description = addedEntity.Description
        };
    }
}
