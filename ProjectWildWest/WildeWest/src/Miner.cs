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
        private const int _comfortLevel = 5;

        // Above this value a miner is thirsty.
        private const int _thirstLevel = 5;

        // The amount of nuggets a miner can carry.
        private const int _maxNuggets = 3;

        // Above this value a miner is sleepy.
        private const int _tirednessThreshold = 5;

        // An instance of the state machine class.
        private readonly StateMachine<Miner> _stateMachine;

        public Location CurrentLocation { get; set; }

        // How many nuggets the miner has in his pockets.
        public int GoldCarried { get; set; }

        // How much money the miner has in the bank.
        public int MoneyInBank { get; set; }

        // The higher the value, the thirstier the miner.
        public int Thirst { get; set; }

        // The higher the value, the more tired the miner.
        public int Fatigue { get; set; }

        public StateMachine<Miner> FSM => _stateMachine;
        public bool PocketIsFull => GoldCarried >= _maxNuggets;
        public bool Thirsty => Thirst >= _thirstLevel;
        public bool Wealthy => MoneyInBank >= _comfortLevel;
        public bool Tired => Fatigue >= _tirednessThreshold;

        public Miner(int id) : base(id)
        {
            CurrentLocation = Location.Shack;
            GoldCarried = 0;
            MoneyInBank = 0;
            Thirst = 0;
            Fatigue = 0;

            _stateMachine = new StateMachine<Miner>(this);
            _stateMachine.SetCurrentState(GoHomeAndSleepTilRested.Instance);
        }

        public override void Update()
        {
            ConsoleUtils.SetTextColor(ConsoleUtils.ColorConfigs.Bob);
            Thirst += 1;
            _stateMachine.Update();
        }

        public override bool HandleMessage(Telegram message) => _stateMachine.HandleMessage(message);

        public void ChangeLocation(Location location) => CurrentLocation = location;
    }
}