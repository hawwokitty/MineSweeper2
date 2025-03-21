using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper2
{
    class ButtonInfo
    {
        public Point Position { get; set; }
        public bool HasBomb { get; set; }

        public ButtonInfo(Point position, bool hasBomb)
        {
            Position = position;
            HasBomb = hasBomb;
        }
    }
}
