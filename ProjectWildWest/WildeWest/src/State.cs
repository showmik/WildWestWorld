namespace WildeWest
{
    internal abstract class State<Entity>
    {
        // This will execute when the state is entered.
        public abstract void Enter(Entity miner);

        // This is the state's normal update function.
        public abstract void Execute(Entity miner);

        // This will execute when the state is exited.
        public abstract void Exit(Entity miner);
    }
}