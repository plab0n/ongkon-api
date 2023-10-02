using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ongkon.Contracts.Interfaces;

namespace Ongkon.Contracts.Models
{
    public class WhiteBoardElement : IWhiteBoardElement
    {
        public string Id { get; set; }
        public Shape Shape { get; set; }
        public double OffsetX { get; set; }
        public double OffsetY { get; set; }
    }
    public class Shape
    {
        public string Type { get; set; }
        public string Name { get; set; }
    }
}
