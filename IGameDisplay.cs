using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsters
{
    public interface IGameDisplay
    {
        void Render(int[,] tiles);
    }
}
