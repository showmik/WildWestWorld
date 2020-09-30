using Miscellaneous;
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

        private WifesGlobalState()
        {
        }

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

        public override bool OnMessage(MinersWife wife, Telegram telegram)
        {
            switch (telegram.message)
            {
                case (int)Message.MessageTypes.HiHoneyImHome:
                    {
                        Console.WriteLine($"Message handled by {wife.Name} at time: {Clock.CurrentTime:N3}");
                        ConsoleUtils.SetTextColor(ConsoleUtils.ColorConfigs.Elsa);
                        Console.WriteLine($"{wife.Name}: Hi honey. Let me make you some of mah fine country stew");
                        wife.GetFSM().ChangeState(CookStew.Instance);
                    }
                    return true;
            }
            return false;
        }
    }
}