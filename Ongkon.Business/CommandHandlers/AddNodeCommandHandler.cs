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
    public class AddNodeCommandHandler : ICommandHandler<AddNodeCommand>
    {
        private IRepositoryContext _repositoryContext;
        public AddNodeCommandHandler(IRepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public async Task<ExpandoObject> Handle(AddNodeCommand command)
        {
            var whiteBoard = await _repositoryContext.GetById<WhiteBoard>("db", command.WhiteBoardId);
            var node = new Node()
            {
                Id = Guid.NewGuid().ToString(),
                Shape = command.Shape,
                Height = command.Height,
                Width = command.Width,
                Position = command.Position
            };
            whiteBoard.AddNode(node);
            //ToDO: In case of concurrent write there might be inconsistencies. Need to resolve it. A simple solution might be to switch to a relational db.
            await _repositoryContext.Save<WhiteBoard>("db", whiteBoard);
            return new ExpandoObject();
        }
    }
}
