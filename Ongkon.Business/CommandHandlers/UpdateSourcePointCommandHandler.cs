using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ongkon.Contracts.Commands;
using Ongkon.Contracts.Interfaces;
using Ongkon.Contracts.Models;

namespace Ongkon.Business.CommandHandlers
{
    public class UpdateSourcePointCommandHandler : ICommandHandler<UpdateSourcePointCommand>
    {
        private IRepositoryContext _repositoryContext;

        public UpdateSourcePointCommandHandler(IRepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public async Task<ExpandoObject> Handle(UpdateSourcePointCommand command)
        {
            var whiteBoard = await _repositoryContext.GetById<WhiteBoard>("db", command.WhiteBoardId);
            if (whiteBoard == null)
            {
                throw new Exception("Whiteboard not found");
            }
            var connector = whiteBoard.GetConnector(command.ConnectorId);
            if (connector != null)
            {
                connector.SourcePoint = command.SourcePoint;
                await _repositoryContext.Save<WhiteBoard>("db", whiteBoard);
                return new ExpandoObject();

            }

            throw new Exception("No connector found");
        }
    }
}
