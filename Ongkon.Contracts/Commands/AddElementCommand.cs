using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ongkon.Contracts.Models;

namespace Ongkon.Contracts.Commands
{
    public class AddElementCommand : CommandBase
    {
        public string WhiteBoardId { get; set; }
        public Element Element { get; set; }
    }

    public class Element
    {
        public string Id { get; set; }
        public Shape Shape { get; set; }
        public double OffsetX { get; set; }
        public double OffsetY { get; set; }
    }
}
