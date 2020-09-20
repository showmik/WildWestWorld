using System;
using System.Collections.Generic;
using System.Text;

namespace WildeWest
{
    class VisitBankAndDepositGold : State<Miner>
    {
        private static VisitBankAndDepositGold instance = null;
        public static VisitBankAndDepositGold Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VisitBankAndDepositGold();
                }
                return instance;
            }
        }

        private VisitBankAndDepositGold() { }

        public override void Enter(Miner miner)
        {
            if (miner.CurrentLocation != Location.Bank)
            {
                Console.WriteLine($"{miner.Name}: Goin' to the bank. Yes siree");
                miner.ChangeLocation(Location.Bank);
            }
        }

        public override void Execute(Miner miner)
        {
            if(miner.GoldCarried > 0)
            {
                miner.MoneyInBank += miner.GoldCarried;
                miner.GoldCarried = 0;
                Console.WriteLine($"{miner.Name}: Depositin’ gold. Total savings now: {miner.MoneyInBank}");
            }

            if(miner.MoneyInBank > 15 || miner.Fatigue > 6)
            {
                miner.GetFSM().ChangeState(GoHomeAndSleepTilRested.Instance);
            }
            else
            {
                miner.GetFSM().ChangeState(EnterMineAndDigForNugget.Instance);
            }
        }

        public override void Exit(Miner miner)
        {
            Console.WriteLine($"{miner.Name}: Leavin' the bank");
        }
    }
}
