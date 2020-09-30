//------------------------------------------------------------------------
//
//  Name:   Miner.cs
//
//  Desc:   A class defining a goldminer.
//
//------------------------------------------------------------------------

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

        // An instance of the state machine class.
        private readonly StateMachine<Miner> stateMachine;

        public Location CurrentLocation { get; set; }

        // How many nuggets the miner has in his pockets.
        public int GoldCarried { get; set; }

        // How much money the miner has in the bank.
        public int MoneyInBank { get; set; }

        // The higher the value, the thirstier the miner.
        public int Thirst { get; set; }

        // The higher the value, the more tired the miner.
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
            ConsoleUtils.SetTextColor(ConsoleUtils.ColorConfigs.Bob);
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