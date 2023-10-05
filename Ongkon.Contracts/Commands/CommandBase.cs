using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ongkon.Contracts.Commands
{
    public class CommandBase
    {
        public string Id { get; set; }

        public CommandBase()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
