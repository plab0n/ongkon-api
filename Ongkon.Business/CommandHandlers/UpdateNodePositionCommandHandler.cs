using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ongkon.Contracts.Commands;
using Ongkon.Contracts.Constants;
using Ongkon.Contracts.Interfaces;
using Ongkon.Contracts.Models;

namespace Ongkon.Business.CommandHandlers
{
    public class UpdateNodePositionCommandHandler : ICommandHandler<UpdateNodePositionCommand>
    {
        private IRepositoryContext _repository;
        public UpdateNodePositionCommandHandler(IRepositoryContext repository)
        {
            _repository = repository;
        }
        public async Task<ExpandoObject> Handle(UpdateNodePositionCommand command)
        {
            var whiteBoard = await _repository.GetById<WhiteBoard>(Db.Name, command.WhiteBoardId);
            if (whiteBoard == null)
            {
                throw new Exception("Whiteboard not found");
            }
            var node = whiteBoard.GetNode(command.NodeId);
            if (node == null)
            {
                throw new Exception("Node not found");
            }
            node.Position = command.Position;
            await _repository.Save<WhiteBoard>(Db.Name, whiteBoard);
            return new ExpandoObject();
        }
    }
}
