using System;

namespace WildeWest
{
    internal class MinersWife : BaseGameEntity
    {
        public enum Location { GoldMine, Bank, Home, Saloon };

        private StateMachine<MinersWife> stateMachine;
        public Location CurrentLocation { get; set; }


        public MinersWife(int id) : base(id)
        {
            stateMachine = new StateMachine<MinersWife>(this);
            stateMachine.SetCurrentState(DoHouseWork.Instance);
            stateMachine.SetGlobalState(WifesGlobalState.Instance);
        }

        public override void Update()
        {
            stateMachine.Update();
        }

        public StateMachine<MinersWife> GetFSM()
        {
            return stateMachine;
        }
    }
}