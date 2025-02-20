using CafeManagement.Application.Contracts.Responses;
using CafeManagement.Application.Features.CafeMenu.Command.CreateCafeMenu;
using CafeManagement.Application.Features.CafeMenu.Command.DeleteCafeMenu;
using CafeManagement.Application.Features.CafeMenu.Command.UpdateCafeMenu;
using CafeManagement.Application.Features.CafeMenu.Dto;
using CafeManagement.Application.Features.CafeMenu.Queries.GetAllCafeMenu;
using CafeManagement.Application.Features.CafeMenu.Queries.GetAllCafeMenusQuery;
using CafeManagement.Application.Features.CafeMenu.Queries.GetCafeMenuByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCafeMenus()
        {
            var response = await _mediator.Send(new GetAllCafeMenusQueryRequest());
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetCafeMenuById(Guid id)
        {
            var response = await _mediator.Send(new GetCafeMenuByIdQueryRequest(id));
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("search")]
        public async Task<IPagedDataResponse<CafeMenuDto>> SearchAsync(GetAllCafeMenuQueryRequest request)
        {
            return await _mediator.Send(request);
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
