using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsters
{
    public class GameBoard
    {
        public int[,] Tiles { get; }

        public GameBoard(int width, int height)
        {
            this.Tiles = new int[width, height];
        }

    }
}
