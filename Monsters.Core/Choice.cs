using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsters
{
    public class Choice
    {
        public Direction Direction { get; }

        public Option Option { get; }

        public Choice(Direction direction, Option option)
        {
            this.Direction = direction;
            this.Option = option;
        }
    }
}
