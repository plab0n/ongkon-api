using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ongkon.Contracts.Commands
{
    public class AddNodeAnnotationCommand : CommandBase
    {
        public string WhiteBoardId { get; set; }
        public string NodeId { get; set; }
        public string Text { get; set; }
    }
}
