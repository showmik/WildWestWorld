using System;

//------------------------------------------------------------------------
//  In this state the miner will walk to a goldmine and pick up a nugget
//  of gold. If the miner already has a nugget of gold he'll change state
//  to VisitBankAndDepositGold. If he gets thirsty he'll change state
//  to QuenchThirst
//------------------------------------------------------------------------

namespace WildeWest
{
    internal class EnterMineAndDigForNugget : State<Miner>
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

        private EnterMineAndDigForNugget() { }

        public override void Enter(Miner miner)
        {
            if (miner.CurrentLocation != Miner.Location.GoldMine)
            {
                Console.WriteLine($"{miner.Name}: Wakin' to the gold mine");
                miner.ChangeLocation(Miner.Location.GoldMine);
            }
        }

        public override void Execute(Miner miner)
        {
            miner.GoldCarried++;
            miner.Fatigue++;
            Console.WriteLine($"{miner.Name}: Pickin' up a nugget");

            if (miner.PocketIsFull())
            {
                miner.GetFSM().ChangeState(VisitBankAndDepositGold.Instance);
            }

            if (miner.Thirsty())
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