using System.Dynamic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Ongkon.Business.CommandHandlers;
using Ongkon.Contracts.Commands;
using Ongkon.Contracts.Interfaces;

namespace Ongkon.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WhiteBoardController : ControllerBase
    {
        private ICommandHandler<CreateWhiteBoardCommand> _whiteBoardCommandHandlerHandler;
        public WhiteBoardController(ICommandHandler<CreateWhiteBoardCommand> commandHandler)
        {
            _whiteBoardCommandHandlerHandler = commandHandler;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateWhiteBoard(CreateWhiteBoardCommand command)
        {
            try
            {
                var data = await _whiteBoardCommandHandlerHandler.Handle(command);
                // var response = new HttpResponseMessage();
                // response.Content.CopyToAsync(data)
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ExpandoObject().TryAdd("error", e.Message));
            }
        }

    }
}
