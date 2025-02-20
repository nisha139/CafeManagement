using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Application.Features.CafeMenu.Command.DeleteCafeMenu;
public class DeleteCafeMenuCommandRequest : IRequest<bool>
{
    public Guid Id { get; set; }
}
