using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ongkon.Contracts.Models
{
    public class Connector
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public Point SourcePoint { get; set; }
        public Point TargetPoint { get; set; }
        public Style style { get; set; }
        public TargetDecorator TargetDecorator { get; set; }
        public Connector() { }
    }

    public class TargetDecorator
    {
        public string Shape { get; set; }
        public Style Style { get; set; }
    }

    public class Style
    {
        public int StrokeWidth { get; set; }
        public string StrokeColor { get; set; }
    }
}
