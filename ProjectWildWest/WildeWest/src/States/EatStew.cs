using System;

namespace WildeWest
{
    internal class EatStew : State<Miner>
    {
        private static EatStew _instance;
        public static EatStew Instance => _instance ??= new EatStew();

        public override void Enter(Miner miner)
        {
            Console.WriteLine($"{miner.Name}: Smells Reaaal goood Elsa!");
        }

        public override void Execute(Miner miner)
        {
            Console.WriteLine($"{miner.Name}: Tastes real good too!");
            miner.FSM.RevertToPreviousState();
        }

        public override void Exit(Miner miner)
        {
            Console.WriteLine($"{miner.Name}: Thankya li'lle lady. Ah better get back to whatever ah wuz doin'");
        }

        public override bool OnMessage(Miner miner, Telegram telegram)
        {
            return false;
        }
    }
}