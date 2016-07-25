using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsters
{
    public class Tile
    {
        public TileState State { get; }

        public int X { get; }

        public int Y { get; }

        public Tile(TileState state, int x, int y)
        {
            this.State = state;
            this.X = x;
            this.Y = y;
        }
    }
}
