using Miscellaneous;
using System;

//------------------------------------------------------------------------
//  Miner will go home and sleep until his fatigue is decreased
//  sufficiently.
//------------------------------------------------------------------------

namespace WildeWest
{
    internal class GoHomeAndSleepTilRested : State<Miner>
    {
        private static GoHomeAndSleepTilRested _instance;
        public static GoHomeAndSleepTilRested Instance => _instance ??= new GoHomeAndSleepTilRested();

        public override void Enter(Miner miner)
        {
            if (miner.CurrentLocation != Miner.Location.Shack)
            {
                Console.WriteLine($"{miner.Name}: Walkin' home");
                miner.ChangeLocation(Miner.Location.Shack);

                MessageDispatcher.Instance.DispatchMessage(0, miner.ID, 1, (int)Message.MessageTypes.HiHoneyImHome);
            }
        }

        public override void Execute(Miner miner)
        {
            if (miner.Tired)
            {
                Console.WriteLine($"{miner.Name}: ZZZZ...");
                miner.Fatigue--;
            }
            else
            {
                miner.FSM.ChangeState(EnterMineAndDigForNugget.Instance);
            }
        }

        public override void Exit(Miner miner)
        {
            Console.WriteLine($"{miner.Name}: What a God-darn fantastic nap! Time to find more gold");
        }

        public override bool OnMessage(Miner miner, Telegram telegram)
        {
            switch (telegram.Message)
            {
                case (int)Message.MessageTypes.StewReady:
                    {
                        Console.WriteLine($"Message handled by {miner.Name} at time: {Clock.CurrentTime:N3}");
                        ConsoleUtils.SetTextColor(ConsoleUtils.ColorConfigs.Bob);
                        Console.WriteLine($"{miner.Name}: Okay hun, ahm a comin'!");

                        miner.
                        FSM.ChangeState(EatStew.Instance);
                    }
                    return true;
            }
            return false;
        }
    }
}