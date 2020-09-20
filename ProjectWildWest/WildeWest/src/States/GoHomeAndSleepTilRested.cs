using System;
using System.Collections.Generic;
using System.Text;

namespace WildeWest
{
    class GoHomeAndSleepTilRested : State<Miner>
    {
        private static GoHomeAndSleepTilRested instance;
        public static GoHomeAndSleepTilRested Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GoHomeAndSleepTilRested();
                }
                return instance;
            }
        }

        public override void Enter(Miner miner)
        {
            if (miner.CurrentLocation != Location.Home)
            {
                Console.WriteLine($"{miner.Name}: Walkin' home");
                miner.ChangeLocation(Location.Home);
            }
        }

        public override void Execute(Miner miner)
        {
            if (miner.Fatigue > 4)
            {
                Console.WriteLine($"{miner.Name}: ZZZZ...");
                miner.Fatigue--;
            }
            else
            {
                miner.GetFSM().ChangeState(EnterMineAndDigForNugget.Instance);
            }
        }

        public override void Exit(Miner miner)
        {
            Console.WriteLine($"{miner.Name}: What a God-darn fantastic nap! Time to find more gold");
        }
    }
}
