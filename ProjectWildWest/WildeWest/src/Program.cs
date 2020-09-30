using System;
using System.Threading;

namespace WildeWest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Clock clock = new Clock();

            Miner miner = new Miner(0);
            MinersWife minersWife = new MinersWife(1);

            miner.Name = "Miner Bob";
            minersWife.Name = "Elsa";

            EntityManager.Instance.RegisterEntity(miner);
            EntityManager.Instance.RegisterEntity(minersWife);

            for (int i = 0; i < 30; i++)
            {
                miner.Update();
                minersWife.Update();
                MessageDispatcher.Instance.DispatchDelayedMessage();

                Thread.Sleep(500);
                //Console.WriteLine($"{Clock.CurrentTime:N2}");
            }

            Console.ReadKey();
        }
    }
}