using System;

namespace WildeWest
{
    internal class DoHouseWork : State<MinersWife>
    {
        private static DoHouseWork instance;

        public static DoHouseWork Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DoHouseWork();
                }
                return instance;
            }
        }

        private DoHouseWork()
        {
        }

        public override void Enter(MinersWife wife)
        {
        }

        public override void Execute(MinersWife wife)
        {
            Random random = new Random();

            switch (random.Next(3))
            {
                case 0:
                    Console.WriteLine($"{wife.Name}: Moppin' the floor");
                    break;

                case 1:
                    Console.WriteLine($"{wife.Name}: Washin' the dishes");
                    break;

                case 2:
                    Console.WriteLine($"{wife.Name}: Makin' the bed");
                    break;
            }
        }

        public override void Exit(MinersWife minersWife)
        {
        }
    }
}