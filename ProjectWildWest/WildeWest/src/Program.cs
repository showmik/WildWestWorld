using System;
using System.Threading;

namespace WildeWest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Miner bob = new Miner(0);
            MinersWife elsa = new MinersWife(1);
            bob.Name = "Miner Bob";
            elsa.Name = "Elsa";
            for (int i = 0; i < 30; i++)
            {
                bob.Update();
                elsa.Update();
                Thread.Sleep(800);
            }

            Console.ReadKey();
        }
    }
}