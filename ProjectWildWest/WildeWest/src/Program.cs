using System;
using System.Threading;

namespace WildeWest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
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

                Thread.Sleep(800);
            }

            Console.ReadKey();
        }
    }
}