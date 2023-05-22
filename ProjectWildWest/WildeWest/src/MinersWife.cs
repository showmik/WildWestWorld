namespace WildeWest
{
    internal partial class MinersWife : BaseGameEntity
    {
        private readonly StateMachine<MinersWife> _stateMachine;
        public StateMachine<MinersWife> FSM => _stateMachine;
        public Location CurrentLocation { get; set; }
        public bool IsCooking { get; set; }

        public MinersWife(int id) : base(id)
        {
            IsCooking = false;
            _stateMachine = new StateMachine<MinersWife>(this);
            _stateMachine.SetCurrentState(DoHouseWork.Instance);
            _stateMachine.SetGlobalState(WifesGlobalState.Instance);
        }

        public override bool HandleMessage(Telegram message) => _stateMachine.HandleMessage(message);

        public override void Update()
        {
            ConsoleUtils.SetTextColor(ConsoleUtils.ColorConfigs.Elsa);
            _stateMachine.Update();
        }
    }
}