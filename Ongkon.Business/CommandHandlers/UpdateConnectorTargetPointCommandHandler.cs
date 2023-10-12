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
    public class UpdateConnectorTargetPointCommandHandler : ICommandHandler<UpdateConnectorTargetPointCommand>
    {
        private IRepositoryContext _repositoryContext;

        public UpdateConnectorTargetPointCommandHandler(IRepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<ExpandoObject> Handle(UpdateConnectorTargetPointCommand command)
        {
            var whiteBoard = await _repositoryContext.GetById<WhiteBoard>(Db.Name, command.WhiteBoardId);
            if (whiteBoard == null)
            {
                throw new Exception("Whiteboard not found.");
            }

            var connector = whiteBoard.GetConnector(command.ConnectorId);
            if (connector == null)
            {
                throw new Exception("Connector not found.");
            }
            connector.TargetPoint = command.TargetPoint;
            await _repositoryContext.Save<WhiteBoard>(Db.Name, whiteBoard);
            return new ExpandoObject();
        }
    }
}
