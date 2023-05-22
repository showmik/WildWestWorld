using System;

//-------------------------------------------------------------------------
// If at any time the miner feels thirsty, he changes to this state and
// visits the saloon in order to buy a whiskey. When his thirst is quenched,
// he changes state to EnterMineAndDigForNugget.
//-------------------------------------------------------------------------

namespace WildeWest
{
    internal class QuenchThirst : State<Miner>
    {
        private static QuenchThirst _instance;
        public static QuenchThirst Instance => _instance ??= new QuenchThirst();

        public override void Enter(Miner miner)
        {
            if (miner.CurrentLocation != Miner.Location.Saloon)
            {
                Console.WriteLine($"{miner.Name}: Boy, ah sure is thusty! Walkin' to the saloon");
                miner.ChangeLocation(Miner.Location.Saloon);
            }
        }

        public override void Execute(Miner miner)
        {
            Console.WriteLine($"{miner.Name}: That's mighty fine sippin liquor");
            miner.Thirst = 0;
            miner.FSM.ChangeState(EnterMineAndDigForNugget.Instance);
        }

        public override void Exit(Miner miner)
        {
            Console.WriteLine($"{miner.Name}: Leavin' the saloon, feelin' good");
        }

        public override bool OnMessage(Miner miner, Telegram message)
        {
            return false;
        }
    }
}