using System;

namespace WildeWest
{
    internal class EatStew : State<Miner>
    {
        private static EatStew instance;

        public static EatStew Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EatStew();
                }
                return instance;
            }
        }

        private EatStew()
        {
        }

        public override void Enter(Miner miner)
        {
            Console.WriteLine($"{miner.Name}: Smells Reaaal goood Elsa!");
        }

        public override void Execute(Miner miner)
        {
            Console.WriteLine($"{miner.Name}: Tastes real good too!");
            miner.GetFSM().RevertToPreviousState();
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