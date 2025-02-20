using CafeManagement.Application.Persistence.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Application.Features.CafeMenu.Command.DeleteCafeMenu;
public class DeleteCafeMenuHandler : IRequestHandler<DeleteCafeMenuCommandRequest, bool>
{
    private readonly ICommandUnitOfWork _unitOfWork;

    public DeleteCafeMenuHandler(ICommandUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteCafeMenuCommandRequest request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.CommandRepository<Domain.Entities.CafeMenu>();
        var cafeMenu = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (cafeMenu == null)
        {
            throw new KeyNotFoundException("Cafe menu item not found.");
        }

        repository.Remove(cafeMenu);
        await _unitOfWork.SaveAsync(cancellationToken);

        return true;
    }
}
