using Miscellaneous;
using System;

namespace WildeWest
{
    internal class CookStew : State<MinersWife>
    {
        private static CookStew _instance;
        public static CookStew Instance => _instance ??= new CookStew();

        public override void Enter(MinersWife wife)
        {
            if (!wife.IsCooking)
            {
                ConsoleUtils.SetTextColor(ConsoleUtils.ColorConfigs.Elsa);
                Console.WriteLine($"{wife.Name}: Puttin' the stew in the oven");
                MessageDispatcher.Instance.DispatchMessage(1.5, wife.ID, wife.ID, (int)Message.MessageTypes.StewReady);
                wife.IsCooking = true;
            }
        }

        public override void Execute(MinersWife wife)
        {
            //ConsoleUtils.SetTextColor(ConsoleUtils.ColorConfigs.Elsa);
            Console.WriteLine($"{wife.Name}: Fussin' over food");
        }

        public override void Exit(MinersWife wife)
        {
            ConsoleUtils.SetTextColor(ConsoleUtils.ColorConfigs.Elsa);
            Console.WriteLine($"{wife.Name}: Putin' the stew on the table");
        }

        public override bool OnMessage(MinersWife wife, Telegram telegram)
        {
            switch (telegram.Message)
            {
                case (int)Message.MessageTypes.StewReady:
                    {
                        Console.WriteLine($"Message recieved by {wife.Name} at time: {Clock.CurrentTime:N3}");
                        ConsoleUtils.SetTextColor(ConsoleUtils.ColorConfigs.Elsa);
                        Console.WriteLine($"{wife.Name}: StewReady! Lets eat");

                        MessageDispatcher.Instance.DispatchMessage(0, wife.ID, 0, (int)Message.MessageTypes.StewReady);
                        wife.IsCooking = false;
                        wife.FSM.ChangeState(DoHouseWork.Instance);
                    }
                    return true;
            }
            return false;
        }
    }
}