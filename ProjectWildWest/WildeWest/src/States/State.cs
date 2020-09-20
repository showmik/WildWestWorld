using System;
using System.Collections.Generic;
using System.Text;

namespace WildeWest
{
    abstract class State<Entity>
    {
        public enum Location { GoldMine, Bank, Home, Saloon };
        public abstract void Enter(Entity miner);
        public abstract void Execute(Entity miner);
        public abstract void Exit(Entity miner);
    }
}
