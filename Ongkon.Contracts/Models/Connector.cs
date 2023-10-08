

namespace Ongkon.Contracts.Models
{
    public class Connector
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public Point SourcePoint { get; set; }
        public Point TargetPoint { get; set; }
        public Connector() { }
    }

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
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
