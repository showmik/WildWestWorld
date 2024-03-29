﻿using System;

//------------------------------------------------------------------------
//  Entity will go to a bank and deposit any nuggets he is carrying. If the
//  miner is subsequently wealthy enough he'll walk home, otherwise he'll
//  keep going to get more gold.
//------------------------------------------------------------------------

namespace WildeWest
{
    internal class VisitBankAndDepositGold : State<Miner>
    {
        private static VisitBankAndDepositGold _instance;
        public static VisitBankAndDepositGold Instance => _instance ??= new VisitBankAndDepositGold();

        public override void Enter(Miner miner)
        {
            if (miner.CurrentLocation != Miner.Location.Bank)
            {
                Console.WriteLine($"{miner.Name}: Goin' to the bank. Yes siree");
                miner.ChangeLocation(Miner.Location.Bank);
            }
        }

        public override void Execute(Miner miner)
        {
            miner.MoneyInBank += miner.GoldCarried;
            miner.GoldCarried = 0;
            Console.WriteLine($"{miner.Name}: Depositin’ gold. Total savings now: {miner.MoneyInBank}");

            if (miner.Wealthy)
            {
                Console.WriteLine($"{miner.Name}: WooHoo! Rich enough for now. Back home to mah li'lle lady");
                miner.FSM.ChangeState(GoHomeAndSleepTilRested.Instance);
            }
            else
            {
                miner.FSM.ChangeState(EnterMineAndDigForNugget.Instance);
            }
        }

        public override void Exit(Miner miner)
        {
            Console.WriteLine($"{miner.Name}: Leavin' the bank");
        }

        public override bool OnMessage(Miner miner, Telegram message)
        {
            return false;
        }
    }
}