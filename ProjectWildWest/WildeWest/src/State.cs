namespace WildeWest
{
    internal abstract class State<Entity>
    {
        // This will execute when the state is entered.
        public abstract void Enter(Entity owner);

        // This is the state's normal update function.
        public abstract void Execute(Entity owner);

        // This will execute when the state is exited.
        public abstract void Exit(Entity owner);

        public abstract bool OnMessage(Entity owner, Telegram telegram);
    }
}