using System.Dynamic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Ongkon.Business.CommandHandlers;
using Ongkon.Contracts.Commands;
using Ongkon.Contracts.Interfaces;
using Ongkon.Contracts.Models;

namespace Ongkon.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WhiteBoardController : ControllerBase
    {
        private ICommandHandler<CreateWhiteBoardCommand> _whiteBoardCommandHandlerHandler;
        private ICommandHandler<AddElementCommand> _addElementCommandHandler;
        private IQueryHandler<WhiteBoard> _whiteBoardQueryHandler;
        private ICommandHandler<AddNodeCommand> _addNodeCommandHandler;
        public WhiteBoardController(ICommandHandler<CreateWhiteBoardCommand> commandHandler, 
            IQueryHandler<WhiteBoard> whiteBoardQueryHandler, 
            ICommandHandler<AddElementCommand> addElementCommandHandler, ICommandHandler<AddNodeCommand> addNodeCommandHandler)
        {
            _whiteBoardCommandHandlerHandler = commandHandler;
            _addElementCommandHandler = addElementCommandHandler;
            _addNodeCommandHandler = addNodeCommandHandler;
            _whiteBoardQueryHandler = whiteBoardQueryHandler;
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
        [HttpGet()]
        public async Task<IActionResult> CreateWhiteBoard(string id) {
            try
            {
                var query = new WhiteBoardQuery()
                {
                    Id = id
                };
                var data = await _whiteBoardQueryHandler.Get(query);
                // var response = new HttpResponseMessage();
                // response.Content.CopyToAsync(data)
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ExpandoObject().TryAdd("error", e.Message));
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> CreateWhiteBoard(AddElementCommand command)
        {
            try
            {
                var data = await _addElementCommandHandler.Handle(command);
                // var response = new HttpResponseMessage();
                // response.Content.CopyToAsync(data)
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ExpandoObject().TryAdd("error", e.Message));
            }
        }
        [HttpPost("Node/Add")]
        public async Task<IActionResult> AddNode(AddNodeCommand command)
        {
            try
            {
                var data = await _addNodeCommandHandler.Handle(command);
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
