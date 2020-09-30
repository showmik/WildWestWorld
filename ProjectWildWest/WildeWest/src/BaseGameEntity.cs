//------------------------------------------------------------------------
//
//  Name:   BaseGameEntity.cs
//
//  Desc:   Base class for a game object
//
//------------------------------------------------------------------------

using System;

namespace WildeWest
{
    internal abstract class BaseGameEntity
    {
        public string Name { get; set; }

        // This is the next valid ID. Each time a BaseGameEntity is instantiated
        // this value is updated
        protected static int nextValidID;

        // Every entity has a unique ID number.
        protected int id;

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

        //---------------------------- HandleMessage-- --------------
        //all entities can communicate using messages. They are sent
        //using the MessageDispatcher singleton class
        //-----------------------------------------------------------

        public abstract bool HandleMessage(Telegram message);
    }
}