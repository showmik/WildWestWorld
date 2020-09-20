using System;

namespace WildeWest
{
    abstract class BaseGameEntity
    {
        protected int id;
        protected static int nextValidID;
        public int ID
        {
            get { return id; }
            set
            {
                if (value >= nextValidID)
                {
                    id = value;
                    nextValidID = id;
                    nextValidID++;
                }
                else
                {
                    Console.WriteLine("Not a valid ID");
                    Console.ReadKey();
                    // close application
                }
            }
        }

        public BaseGameEntity(int id)
        {
            ID = id;
        }

        public abstract void Update();
        
    }
}
