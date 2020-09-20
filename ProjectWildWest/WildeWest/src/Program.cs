using System;
using System.Threading;

namespace WildeWest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Miner bob = new Miner(0);
            bob.Name = "Miner Bob";
            for (int i = 0; i < 30; i++)
            {
                bob.Update();
                Thread.Sleep(800);
            }
            Console.ReadKey();
        }
    }
}