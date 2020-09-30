using System;

namespace WildeWest
{
    internal partial class Miner : BaseGameEntity
    {
        // The amount of gold a miner must have before he feels comfortable.
        private const int comfortLevel = 5;

        // Above this value a miner is thirsty.
        private const int thirstLevel = 5;

        // The amount of nuggets a miner can carry.
        private const int maxNuggets = 3;

        // Above this value a miner is sleepy.
        private const int tirednessThreshold = 5;

        private readonly StateMachine<Miner> stateMachine;

        public Location CurrentLocation { get; set; }
        public int GoldCarried { get; set; }
        public int MoneyInBank { get; set; }
        public int Thirst { get; set; }
        public int Fatigue { get; set; }

        public Miner(int id) : base(id)
        {
            CurrentLocation = Location.Shack;
            GoldCarried = 0;
            MoneyInBank = 0;
            Thirst = 0;
            Fatigue = 0;

            stateMachine = new StateMachine<Miner>(this);
            stateMachine.SetCurrentState(GoHomeAndSleepTilRested.Instance);
        }

        public override bool HandleMessage(Telegram message)
        {
            return stateMachine.HandleMessage(message);
        }

        public override void Update()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Thirst += 1;
            stateMachine.Update();
        }

        public void ChangeLocation(Location location)
        {
            CurrentLocation = location;
        }

        public StateMachine<Miner> GetFSM()
        {
            return stateMachine;
        }

        public bool PocketIsFull()
        {
            if (GoldCarried >= maxNuggets)
            {
                return true;
            }
            return false;
        }

        public bool Thirsty()
        {
            if (Thirst >= thirstLevel)
            {
                return true;
            }
            return false;
        }

        public bool Wealthy()
        {
            if (MoneyInBank >= comfortLevel)
            {
                return true;
            }
            return false;
        }

        public bool Tired()
        {
            if (Fatigue >= tirednessThreshold)
            {
                return true;
            }
            return false;
        }
    }
}