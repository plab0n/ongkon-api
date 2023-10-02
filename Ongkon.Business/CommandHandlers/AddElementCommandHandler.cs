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
    public class AddElementCommandHandler : ICommandHandler<AddElementCommand>
    {
        private IRepositoryContext _repositoryContext;
        public AddElementCommandHandler(IRepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public async Task<ExpandoObject> Handle(AddElementCommand command)
        {
            //TODO: Validate command
            var whiteBoard = await _repositoryContext.GetById<WhiteBoard>("db", command.WhiteBoardId);
            if (whiteBoard == null)
            {
                throw new Exception("Whiteboard not found");
            }
            var whiteBoardElement = new WhiteBoardElement()
            {
                Id = Guid.NewGuid().ToString(),
                Shape = command.Element.Shape,
                OffsetX = command.Element.OffsetX,
                OffsetY = command.Element.OffsetY,
            };
            whiteBoard.AddElement(whiteBoardElement);
            await _repositoryContext.Save<WhiteBoard>("db", whiteBoard);
            return new ExpandoObject();
        }
    }
}
