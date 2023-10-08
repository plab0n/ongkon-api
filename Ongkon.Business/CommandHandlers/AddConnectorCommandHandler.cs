using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Ongkon.Contracts.Commands;
using Ongkon.Contracts.Interfaces;
using Ongkon.Contracts.Models;

namespace Ongkon.Business.CommandHandlers
{
    public class AddConnectorCommandHandler : ICommandHandler<AddConnectorCommand>
    {
        private IRepositoryContext _repositoryContext;

        public AddConnectorCommandHandler(IRepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<ExpandoObject> Handle(AddConnectorCommand command)
        {
            var whiteBoard = await _repositoryContext.GetById<WhiteBoard>("db", command.WhiteBoardId);
            if (whiteBoard == null)
            {
                throw new Exception("Whiteboard not found");
            }
            var connector = new Connector()
            {
                Id = Guid.NewGuid().ToString(),
                SourcePoint = command.SourcePoint,
                TargetPoint = command.TargetPoint,
                Type = command.Type
            };
            whiteBoard.AddConnector(connector);
            await _repositoryContext.Save<WhiteBoard>("db", whiteBoard);
            return new ExpandoObject();
        }
    }
}
