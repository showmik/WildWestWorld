namespace WildeWest
{
    internal partial class MinersWife : BaseGameEntity
    {
        private readonly StateMachine<MinersWife> stateMachine;
        public Location CurrentLocation { get; set; }
        public bool IsCooking { get; set; }

        public MinersWife(int id) : base(id)
        {
            IsCooking = false;
            stateMachine = new StateMachine<MinersWife>(this);
            stateMachine.SetCurrentState(DoHouseWork.Instance);
            stateMachine.SetGlobalState(WifesGlobalState.Instance);
        }

        public override bool HandleMessage(Telegram message)
        {
            return stateMachine.HandleMessage(message);
        }

        public override void Update()
        {
            ConsoleUtils.SetTextColor(ConsoleUtils.ColorConfigs.Elsa);
            stateMachine.Update();
        }

        public StateMachine<MinersWife> GetFSM()
        {
            return stateMachine;
        }
    }
}