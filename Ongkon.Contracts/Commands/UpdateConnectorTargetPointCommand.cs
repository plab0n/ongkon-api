using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ongkon.Contracts.Models;

namespace Ongkon.Contracts.Commands
{
    public class UpdateConnectorTargetPointCommand : CommandBase
    {
        public string WhiteBoardId { get; set; }
        public string ConnectorId { get; set; }
        public Point TargetPoint { get; set; }
    }
}
