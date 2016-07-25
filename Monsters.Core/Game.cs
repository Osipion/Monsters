using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsters
{
    public class Game
    {
        public const int MonsterIdStart = 50;
        public GameBoard Board { get; }
        public int MaxTurns { get; }
        public int CurrentTurn { get; private set; }
        public int TurnsLeft => MaxTurns - CurrentTurn;
        public IReadOnlyDictionary<int, Monster> Monsters { get; }


        public Game(IEnumerable<Monster> monsters, int width = 10, int height = 10, int maxTurns = int.MaxValue)
        {
            if (monsters == null) throw new ArgumentNullException(nameof(monsters));
            var i = MonsterIdStart;
            this.Monsters = new ReadOnlyDictionary<int, Monster>(monsters.ToDictionary(m => i++, m => m));
            this.Board = new GameBoard(width, height);
        }

        public IDictionary<Monster, Tile> GetMonsterPositions()
        {
            var dict = new Dictionary<Monster, Tile>();

            for(var x = 0; x < this.Board.Tiles.GetLength(0); x++)
            {
                for(var y = 0; y < this.Board.Tiles.GetLength(1); y++)
                {
                    var val = this.Board.Tiles[x, y];
                    if(val >= MonsterIdStart)
                    {
                        dict.Add(this.Monsters[val], new Tile(TileState.Enemy, x, y));
                    }
                }
            }
            return dict;
        }
    }
}
