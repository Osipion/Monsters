using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsters
{
    public class GameView
    {
        public int X { get; }

        public int Y { get; }

        public IReadOnlyDictionary<string, Tile> Enemies { get; }

        public IReadOnlyDictionary<Direction, Tile> Surroundings { get; }

        private GameView(
            IReadOnlyDictionary<string, Tile> enemies, 
            IReadOnlyDictionary<Direction, Tile> surroundings, 
            int x, 
            int y)
        {
            this.Enemies = enemies;
            this.X = x;
            this.Y = y;
        }

        public static GameView New(Monster viewer, Game game)
        {
            var mPos = game.GetMonsterPositions();
            var vPos = mPos.First(kvp => kvp.Key == viewer);
            var eMap = mPos.Where(kvp => kvp.Key != vPos.Key)
                .ToDictionary(kvp => kvp.Key.Name, kvp => kvp.Value);
            var sMap = getSurroundings(vPos.Value.X, vPos.Value.Y, game.Board.Tiles);
            return new GameView(eMap, sMap, vPos.Value.X, vPos.Value.Y);
        }

        private static IReadOnlyDictionary<Direction, Tile> getSurroundings(int x, int y, int[,] board)
        {
            return new ReadOnlyDictionary<Direction, Tile>(new Dictionary<Direction, Tile>
            {
                [Direction.Down ]   = getTile(x     , y + 1, board),
                [Direction.Up   ]   = getTile(x     , y - 1, board),
                [Direction.Left ]   = getTile(x - 1 , y    , board),
                [Direction.Right]   = getTile(x + 1 , y    , board)
            });
        }

        private static Tile getTile(int x, int y, int[,] board)
        {
            var isOutOfBounds =
                x >= board.GetLength(0) ||
                y >= board.GetLength(1) ||
                x < 0                   ||
                y < 0;

            if (isOutOfBounds) return new Tile(TileState.Blocked, x, y);
            var val = board[x, y];
            if (val >= Game.MonsterIdStart) return new Tile(TileState.Enemy, x, y);
            return new Tile((TileState)val, x, y);
        }
    }
}
