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
    public class CreateWhiteBoardCommandHandler : ICommandHandler<CreateWhiteBoardCommand>
    {
        private IRepositoryContext<WhiteBoard> _repositoryContext;
        public CreateWhiteBoardCommandHandler(IRepositoryContext<WhiteBoard> repositoryContext)
        {
            _repositoryContext=repositoryContext;
        }
        public async Task<ExpandoObject> Handle(CreateWhiteBoardCommand command)
        {
            //Check if whiteboard with same title exists or not
            //If not create a new one and save it to db
            //Otherwise through exception White board exist with same title
            if (string.IsNullOrEmpty(command.Title))
            {
                throw new Exception("A title is required");
            }
            var whiteBoard = new WhiteBoard()
            {
                Id = Guid.NewGuid().ToString(),
                Title = command.Title,
            };
            await _repositoryContext.Save<WhiteBoard>("db", whiteBoard);
            var expandoObject = new ExpandoObject();
            expandoObject.TryAdd("id", whiteBoard.Id);
            return expandoObject;
        }
    }
}
