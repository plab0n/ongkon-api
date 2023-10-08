
using Point = Ongkon.Contracts.Models.Point;

namespace Ongkon.Contracts.Commands
{
    public class AddConnectorCommand : CommandBase
    {
        public string WhiteBoardId { get; set; }
        public string Type { get; set; }
        public Point SourcePoint { get; set; }
        public Point TargetPoint { get; set; }
    }
}
