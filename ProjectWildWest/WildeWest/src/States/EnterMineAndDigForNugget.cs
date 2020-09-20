using System;
using System.Collections.Generic;
using System.Text;

namespace WildeWest
{
    class EnterMineAndDigForNugget : State<Miner>
    {
        private static EnterMineAndDigForNugget instance;
        public static EnterMineAndDigForNugget Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnterMineAndDigForNugget();
                }
                return instance;
            }
        }

        public override void Enter(Miner miner)
        {
            if (miner.CurrentLocation != Location.GoldMine)
            {
                Console.WriteLine($"{miner.Name}: Wakin' to the gold mine");
                miner.ChangeLocation(Location.GoldMine);
            }
        }

        public override void Execute(Miner miner)
        {
            miner.GoldCarried++;
            miner.Fatigue++;
            Console.WriteLine($"{miner.Name}: Pickin' up a nugget");

            if(miner.PocketIsFull())
            {
                miner.GetFSM().ChangeState(VisitBankAndDepositGold.Instance);
            }

            if(miner.Thirsty())
            {
                miner.GetFSM().ChangeState(QuenchThirst.Instance);
            }
        }

        public override void Exit(Miner miner)
        {
            Console.WriteLine($"{miner.Name}: Ah'm leavin' the gold mine with mah pockets full o' sweet gold");
        }
    }
}
