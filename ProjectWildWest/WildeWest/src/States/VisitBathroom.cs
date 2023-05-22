using System;

namespace WildeWest
{
    internal class VisitBathroom : State<MinersWife>
    {
        private static VisitBathroom _instance;
        public static VisitBathroom Instance => _instance ??= new VisitBathroom();

        public override void Enter(MinersWife wife)
        {
            Console.WriteLine($"{wife.Name}: Walkin' to the can. Need to powda mah pretty li'lle nose");
        }

        public override void Execute(MinersWife wife)
        {
            Console.WriteLine($"{wife.Name}: Ahhhhhh! Sweet relief!");
            wife.FSM.RevertToPreviousState();
        }

        public override void Exit(MinersWife wife)
        {
            Console.WriteLine($"{wife.Name}: Leavin' the Jon");
        }

        public override bool OnMessage(MinersWife miner, Telegram message)
        {
            return false;
        }
    }
}