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
        public const double SmallestDelay = 0.25d;

        public int Sender { get; }
        public int Reciever { get; }
        public int Message { get; }
        public double DispatchTime { get; set; }

        public Telegram()
        {
            Sender = -1;
            Reciever = -1;
            Message = -1;
            DispatchTime = -1;
        }

        public Telegram(double time, int sender, int reciever, int msg)
        {
            DispatchTime = time;
            this.Sender = sender;
            this.Reciever = reciever;
            Message = msg;
        }

        public static bool IsEqual(Telegram t1, Telegram t2)
        {
            return Math.Abs((t1.DispatchTime - t2.DispatchTime)) < SmallestDelay
                && (t1.Sender == t2.Sender)
                && (t1.Reciever == t2.Reciever)
                && (t1.Message == t2.Message);
        }

        public bool IsLessThan(Telegram telegram) => !IsEqual(this, telegram) && DispatchTime < telegram.DispatchTime;
    }
}