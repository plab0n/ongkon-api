using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ongkon.Contracts.Commands;
using Ongkon.Contracts.Interfaces;

namespace Ongkon.Business.CommandHandlers
{
    public class CreateWhiteBoardCommandHandler : ICommandHandler<CreateWhiteBoardCommand>
    {
        public async Task<ExpandoObject> Handle(CreateWhiteBoardCommand command)
        {
            //Check if whiteboard with same title exists or not
            //If not create a new one and save it to db
            //Otherwise through exception White board exist with same title
            var expandoObject = new ExpandoObject();
            expandoObject.TryAdd("Id", "some_guid");
            return expandoObject;
        }
    }
}
