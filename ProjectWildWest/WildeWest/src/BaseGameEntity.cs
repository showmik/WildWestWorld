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
        // Every entity has a unique ID number.
        protected int _id;

        // This is the next valid ID. Each time a BaseGameEntity is instantiated
        // this value is updated
        protected static int _nextValidID;

        public int ID
        {
            get { return _id; }
            set
            {
                if (value >= _nextValidID)
                {
                    _id = value;
                    _nextValidID = _id + 1;
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

        public string Name { get; set; }

        public BaseGameEntity(int id) => ID = id;

        public abstract void Update();

        //---------------------------- HandleMessage-- --------------
        //all entities can communicate using messages. They are sent
        //using the MessageDispatcher singleton class
        //-----------------------------------------------------------

        public abstract bool HandleMessage(Telegram message);
    }
}