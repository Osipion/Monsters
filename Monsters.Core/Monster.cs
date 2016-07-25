namespace Monsters
{
    public abstract class Monster
    {
        public abstract string Name { get; }

        public abstract Choice TakeTurn(GameView view);

    }
}
