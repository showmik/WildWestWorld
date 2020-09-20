namespace WildeWest
{
    internal abstract class State<Entity>
    {
        

        //this will execute when the state is entered
        public abstract void Enter(Entity miner);

        //this is the state's normal update function
        public abstract void Execute(Entity miner);

        //this will execute when the state is exited
        public abstract void Exit(Entity miner);
    }
}