using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsters
{
    class Program
    {
        static void Main(string[] args)
        {
            var ints = new int[5, 5];
            for(var i = 0; i < ints.GetLength(0); i++)
            {
                for(var j = 0; j < ints.GetLength(1); j++)
                {
                    ints[i, j] = j;
                }
            }
            var display = new GameDisplay();
            display.ColorBindings = new Dictionary<int, ConsoleColor>
            {
                [0] = ConsoleColor.Blue,
                [1] = ConsoleColor.Green,
                [2] = ConsoleColor.Yellow,
                [3] = ConsoleColor.Magenta,
                [4] = ConsoleColor.Cyan
            };
            display.Render(ints);
        }
    }
}
