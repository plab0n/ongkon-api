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
    public class UpdateConnectorPositionCommandHandler : ICommandHandler<UpdateConnectorPositionCommand>
    {
        private IRepositoryContext _repositoryContext;
        public UpdateConnectorPositionCommandHandler(IRepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public async Task<ExpandoObject> Handle(UpdateConnectorPositionCommand command)
        {
            var whiteBoard = await _repositoryContext.GetById<WhiteBoard>(Db.Name, command.WhiteBoardId);
            if (whiteBoard==null)
            {
                throw new Exception("Whiteboard not found.");
            }

            var connector = whiteBoard.GetConnector(command.ConnectorId);
            connector.SourcePoint = command.SourcePoint;
            connector.TargetPoint = command.TargetPoint;
            await _repositoryContext.Save<WhiteBoard>(Db.Name, whiteBoard);
            return new ExpandoObject();
        }
    }
}
