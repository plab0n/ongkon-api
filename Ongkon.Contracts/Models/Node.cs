using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ongkon.Contracts.Interfaces;

namespace Ongkon.Contracts.Models
{
    public class Node
    {
        public string Id { get; set; }
        public ElementShape Shape { get; set; }
        public Point Position { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string Text { get; set; }
    }
    public class ElementShape
    {
        public string Type { get; set; }
        public string Shape { get; set; }
    }
}
