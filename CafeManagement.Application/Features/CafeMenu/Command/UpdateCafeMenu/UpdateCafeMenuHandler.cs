using CafeManagement.Application.Features.CafeMenu.Dto;
using CafeManagement.Application.Persistence.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Application.Features.CafeMenu.Command.UpdateCafeMenu;
public class UpdateCafeMenuHandler : IRequestHandler<UpdateCafeMenuCommandRequest, CafeMenuDto>
{
    private readonly ICommandUnitOfWork _unitOfWork;

    public UpdateCafeMenuHandler(ICommandUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CafeMenuDto> Handle(UpdateCafeMenuCommandRequest request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.CommandRepository<Domain.Entities.CafeMenu>();
        var cafeMenu = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (cafeMenu == null)
        {
            throw new KeyNotFoundException("Cafe menu item not found.");
        }

        cafeMenu.Name = request.Name;
        cafeMenu.Price = request.Price;
        cafeMenu.Description = request.Description;

        repository.Update(cafeMenu);
        await _unitOfWork.SaveAsync(cancellationToken);

        return new CafeMenuDto
        {
            Id = cafeMenu.Id,
            Name = cafeMenu.Name,
            Price = cafeMenu.Price,
            Description = cafeMenu.Description
        };
    }
}

