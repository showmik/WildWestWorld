using System;

//------------------------------------------------------------------------
//  Miner will go home and sleep until his fatigue is decreased
//  sufficiently.
//------------------------------------------------------------------------

namespace WildeWest
{
    internal class GoHomeAndSleepTilRested : State<Miner>
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

        private GoHomeAndSleepTilRested() { }

        public override void Enter(Miner miner)
        {
            if (miner.CurrentLocation != Miner.Location.Shack)
            {
                Console.WriteLine($"{miner.Name}: Walkin' home");
                miner.ChangeLocation(Miner.Location.Shack);
            }
        }

        public override void Execute(Miner miner)
        {
            if (miner.Tired())
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