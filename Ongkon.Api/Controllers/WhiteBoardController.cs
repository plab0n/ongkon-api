﻿using System.Dynamic;
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
        private ICommandHandler<AddNodeAnnotationCommand> _addNodeAnnotationCommandHandler;
        private ICommandHandler<AddConnectorCommand> _addConnectorCommandHandler;
        private ICommandHandler<UpdateSourcePointCommand> _updateSourcePointCommandHandler;
        private ICommandHandler<UpdateNodePositionCommand> _updateNodePositionCommandHandler;
        private ICommandHandler<UpdateConnectorPositionCommand> _updateConnectorPositionCommandHandler;
        private ICommandHandler<UpdateConnectorTargetPointCommand> _updateConnectorTargetPointCommandHandler;
        public WhiteBoardController(ICommandHandler<CreateWhiteBoardCommand> commandHandler, 
            IQueryHandler<WhiteBoard> whiteBoardQueryHandler, 
            ICommandHandler<AddElementCommand> addElementCommandHandler, 
            ICommandHandler<AddNodeCommand> addNodeCommandHandler, 
            ICommandHandler<AddNodeAnnotationCommand> addNodeAnnotationCommandHandler, 
            ICommandHandler<AddConnectorCommand> addConnectorCommandHandler, 
            ICommandHandler<UpdateSourcePointCommand> updateSourcePointCommandHandler, ICommandHandler<UpdateNodePositionCommand> updateNodePositionCommandHandler, ICommandHandler<UpdateConnectorPositionCommand> updateConnectorPositionCommandHandler, ICommandHandler<UpdateConnectorTargetPointCommand> updateConnectorTargetPointCommandHandler)
        {
            _whiteBoardCommandHandlerHandler = commandHandler;
            _addElementCommandHandler = addElementCommandHandler;
            _addNodeCommandHandler = addNodeCommandHandler;
            _addNodeAnnotationCommandHandler = addNodeAnnotationCommandHandler;
            _addConnectorCommandHandler = addConnectorCommandHandler;
            _updateSourcePointCommandHandler = updateSourcePointCommandHandler;
            _updateNodePositionCommandHandler = updateNodePositionCommandHandler;
            _updateConnectorPositionCommandHandler = updateConnectorPositionCommandHandler;
            _updateConnectorTargetPointCommandHandler = updateConnectorTargetPointCommandHandler;
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
        [HttpPost("Node/AddAnnotation")]
        public async Task<IActionResult> AddNodeAnnotation(AddNodeAnnotationCommand command)
        {
            try
            {
                var data = await _addNodeAnnotationCommandHandler.Handle(command);
                // var response = new HttpResponseMessage();
                // response.Content.CopyToAsync(data)
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ExpandoObject().TryAdd("error", e.Message));
            }
        }
        [HttpPost("Node/Update/Position")]
        public async Task<IActionResult> UpdateNodePosition(UpdateNodePositionCommand command)
        {
            try
            {
                var data = await _updateNodePositionCommandHandler.Handle(command);
                // var response = new HttpResponseMessage();
                // response.Content.CopyToAsync(data)
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ExpandoObject().TryAdd("error", e.Message));
            }
        }
        [HttpPost("Connector/Add")]
        public async Task<IActionResult> AddNode(AddConnectorCommand command)
        {
            try
            {
                var data = await _addConnectorCommandHandler.Handle(command);
                // var response = new HttpResponseMessage();
                // response.Content.CopyToAsync(data)
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ExpandoObject().TryAdd("error", e.Message));
            }
        }
        [HttpPost("Connector/Update/SourcePoint")]
        public async Task<IActionResult> UpdateSourcePoint(UpdateSourcePointCommand command)
        {
            try
            {
                var data = await _updateSourcePointCommandHandler.Handle(command);
                // var response = new HttpResponseMessage();
                // response.Content.CopyToAsync(data)
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ExpandoObject().TryAdd("error", e.Message));
            }
        }
        [HttpPost("Connector/Update/Position")]
        public async Task<IActionResult> UpdatePosition(UpdateConnectorPositionCommand command)
        {
            try
            {
                var data = await _updateConnectorPositionCommandHandler.Handle(command);
                // var response = new HttpResponseMessage();
                // response.Content.CopyToAsync(data)
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ExpandoObject().TryAdd("error", e.Message));
            }
        }
        [HttpPost("Connector/Update/TargetPoint")]
        public async Task<IActionResult> UpdateConnectorTargetPoint(UpdateConnectorTargetPointCommand command)
        {
            try
            {
                var data = await _updateConnectorTargetPointCommandHandler.Handle(command);
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
