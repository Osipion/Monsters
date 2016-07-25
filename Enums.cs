using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsters
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public enum Option
    {
        Attack,
        Move,
        Pause
    }

    public enum TileState
    {
        Enemy,
        Blocked,
        Empty
    }
}
