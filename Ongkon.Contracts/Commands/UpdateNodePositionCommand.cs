using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ongkon.Contracts.Models;

namespace Ongkon.Contracts.Commands
{
    public class UpdateNodePositionCommand : CommandBase
    {
        public string WhiteBoardId { get; set; }
        public string NodeId { get; set; }
        public Point Position { get; set; }
    }
}
