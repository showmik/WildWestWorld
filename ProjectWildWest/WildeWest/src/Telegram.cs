//------------------------------------------------------------------------
//
//  Name:   Telegram.cs
//
//  Desc:   This defines a telegram. A telegram is a data structure that
//          records information required to dispatch messages. Messages
//          are used by game agents to communicate with each other.
//
//------------------------------------------------------------------------

using System;

namespace WildeWest
{
    internal class Telegram
    {
        // The entity that sent this telegram.
        public int sender;

        // The entity that is to recieve this telegram.
        public int reciever;

        // The message itself. These are all enumerated in the file "MessageTypes.cs"
        public int message;

        // Messages can be dispatched immediately or delayed for a specified amount
        // of time. If a delay is necessary this field is stamped with the time
        // the message should be dispatched.
        public double dispatchTime;

        public Telegram()
        {
            sender = -1;
            reciever = -1;
            message = -1;
            dispatchTime = -1;
        }

        public Telegram(double time, int sender, int reciever, int msg)
        {
            dispatchTime = time;
            this.sender = sender;
            this.reciever = reciever;
            message = msg;
        }

        public const double smallestDelay = 0.25d;

        public static bool IsEqual(Telegram t1, Telegram t2)
        {
            return Math.Abs((t1.dispatchTime - t2.dispatchTime)) < smallestDelay
                && (t1.sender == t2.sender)
                && (t1.reciever == t2.reciever)
                && (t1.message == t2.message);
        }

        public bool IsLessThan(Telegram telegram)
        {
            return !IsEqual(this, telegram) && dispatchTime < telegram.dispatchTime;
        }
    }
}