using System;
using System.Collections.Generic;
using System.Text;

namespace WildeWest
{
    class QuenchThirst : State<Miner>
    {
        private static QuenchThirst instance;
        public static QuenchThirst Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new QuenchThirst();
                }
                return instance;
            }
        }

        public override void Enter(Miner miner)
        {
            if (miner.CurrentLocation != Location.Saloon)
            {
                Console.WriteLine($"{miner.Name}: Boy, ah sure is thusty! Walkin' to the saloon");
                miner.ChangeLocation(Location.Saloon);
            }
        }

        public override void Execute(Miner miner)
        {
            Console.WriteLine($"{miner.Name}: That's mighty fine sippin liquor");
            miner.Thirst = 0;
            miner.GetFSM().ChangeState(EnterMineAndDigForNugget.Instance);
        }

        public override void Exit(Miner miner)
        {
            Console.WriteLine($"{miner.Name}: Leavin' the saloon, feelin' good");
        }
    }
}
