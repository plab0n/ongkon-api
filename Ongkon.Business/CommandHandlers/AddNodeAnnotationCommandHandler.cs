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
    public class AddNodeAnnotationCommandHandler : ICommandHandler<AddNodeAnnotationCommand>
    {
        private IRepositoryContext _repositoryContext;
        public AddNodeAnnotationCommandHandler(IRepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public async Task<ExpandoObject> Handle(AddNodeAnnotationCommand command)
        {
            var whiteBoard = await _repositoryContext.GetById<WhiteBoard>("db", command.WhiteBoardId);
            if (whiteBoard == null)
            {
                throw new Exception("No white board found");
            }
            var node = whiteBoard.GetNode(command.NodeId);
            if (node == null)
            {
                throw new Exception("No node found");
            }
            node.Text = command.Text;
            await _repositoryContext.Save<WhiteBoard>("db", whiteBoard);
            return new ExpandoObject();
        }
    }
}
