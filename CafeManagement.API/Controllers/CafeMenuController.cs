using CafeManagement.Application.Features.CafeMenu.Command.CreateCafeMenu;
using CafeManagement.Application.Features.CafeMenu.Command.DeleteCafeMenu;
using CafeManagement.Application.Features.CafeMenu.Command.UpdateCafeMenu;
using CafeManagement.Application.Features.CafeMenu.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CafeMenuController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CafeMenuController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CafeMenuDto>> Create([FromBody] CreateCafeMenuCommandRequest command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CafeMenuDto>> Update(Guid id, [FromBody] UpdateCafeMenuCommandRequest command)
        {
            if (id != command.Id)
                return BadRequest("ID in URL does not match ID in request body.");

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteCafeMenuCommandRequest { Id = id });
            return result ? Ok(true) : NotFound();
        }
    }
}
