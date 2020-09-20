namespace WildeWest
{
    internal class Miner : BaseGameEntity
    {
        //the amount of gold a miner must have before he feels comfortable
        private const int comfortLevel = 5;
        //above this value a miner is thirsty
        private const int thirstLevel = 5;
        //the amount of nuggets a miner can carry
        private const int maxNuggets = 3;
        //above this value a miner is sleepy
        private const int tirednessThreshold = 5;

        private StateMachine<Miner> stateMachine;

        public enum Location { GoldMine, Bank, Home, Saloon };

        private State<Miner> currentState;
        public Location CurrentLocation { get; set; }
        public string Name { get; set; }
        public int GoldCarried { get; set; }
        public int MoneyInBank { get; set; }
        public int Thirst { get; set; }
        public int Fatigue { get; set; }

        public Miner(int id) : base(id)
        {
            CurrentLocation = Location.Home;
            GoldCarried = 0;
            MoneyInBank = 0;
            Thirst = 0;
            Fatigue = 0;

            stateMachine = new StateMachine<Miner>(this);
            stateMachine.SetCurrentState(GoHomeAndSleepTilRested.Instance);
            stateMachine.SetGlobalState(MinerGlobalState.Instance);
        }

        public override void Update()
        {
            Thirst += 1;
            stateMachine.Update();
        }

        public void ChangeState(State<Miner> newState)
        {
            currentState.Exit(this);
            currentState = newState;
            currentState.Enter(this);
        }

        public void ChangeLocation(Location location)
        {
            CurrentLocation = location;
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

        public StateMachine<Miner> GetFSM()
        {
            return stateMachine;
        }
    }
}