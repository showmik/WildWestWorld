using System;
using System.Threading;

namespace WildeWest
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Miner miner = new Miner(18);
            miner.Name = "Miner Pius";
            for (int i = 0; i < 30; i++)
            {
                miner.Update();
                
            }
            Console.ReadKey();
        }
    }
}
