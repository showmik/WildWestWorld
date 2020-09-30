using System;

namespace WildeWest
{
    internal class VisitBathroom : State<MinersWife>
    {
        private static VisitBathroom instance;

        public static VisitBathroom Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VisitBathroom();
                }
                return instance;
            }
        }

        private VisitBathroom() { }

        public override void Enter(MinersWife wife)
        {
            Console.WriteLine($"{wife.Name}: Walkin' to the can. Need to powda mah pretty li'lle nose");
        }

        public override void Execute(MinersWife wife)
        {
            Console.WriteLine($"{wife.Name}: Ahhhhhh! Sweet relief!");
            wife.GetFSM().RevertToPreviousState();
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