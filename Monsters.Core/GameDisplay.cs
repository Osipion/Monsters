using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsters
{
    public class GameDisplay : IGameDisplay
    {
        public IDictionary<int, ConsoleColor> ColorBindings { get; set; } = 
            new Dictionary<int, ConsoleColor>();

        public void Render(int[,] tiles)
        {
            Console.Clear();
            var origColour = Console.BackgroundColor;

            for (var x = 0; x < tiles.GetLength(0); x++)
            {
                for(var y = 0; y < tiles.GetLength(1); y++)
                {
                    var num = tiles[x, y];
                    ConsoleColor col;
                    if (!this.ColorBindings.TryGetValue(num, out col))
                        col = ConsoleColor.Black;
                    Console.BackgroundColor = col;
                    Console.Write(num.ToString("D2"));
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = origColour;
        }
    }
}
