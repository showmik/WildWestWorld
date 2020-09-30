using System;

namespace WildeWest
{
    internal abstract class BaseGameEntity
    {
        protected int id;
        protected static int nextValidID;
        public string Name { get; set; }

        public int ID
        {
            get { return id; }
            set
            {
                if (value >= nextValidID)
                {
                    id = value;
                    nextValidID = id + 1;
                }
                else
                {
                    Console.WriteLine("Not a valid ID");
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                    Environment.Exit(1);
                }
            }
        }

        public BaseGameEntity(int id)
        {
            ID = id;
        }

        public abstract void Update();

        public abstract bool HandleMessage(Telegram message);
    }
}