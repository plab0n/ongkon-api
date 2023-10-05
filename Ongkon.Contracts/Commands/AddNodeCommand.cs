﻿using Ongkon.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ongkon.Contracts.Commands
{
    public class AddNodeCommand : CommandBase
    {
        public string WhiteBoardId { get; set; }
        public ElementShape Shape { get; set; }
        public Point Position { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public AddNodeCommand() { }

    }
}
