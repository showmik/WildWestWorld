using System;

namespace WildeWest
{
    internal class WifesGlobalState : State<MinersWife>
    {
        private static WifesGlobalState instance;

        public static WifesGlobalState Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WifesGlobalState();
                }
                return instance;
            }
        }

        private WifesGlobalState() { }

        public override void Enter(MinersWife wife)
        {
        }

        public override void Execute(MinersWife wife)
        {
            Random random = new Random();
            if (random.Next(101) <= 10)
            {
                wife.GetFSM().ChangeState(VisitBathroom.Instance);
            }
        }

        public override void Exit(MinersWife wife)
        {
        }
    }
}