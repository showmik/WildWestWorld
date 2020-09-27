using System;

namespace WildeWest
{
    internal class Telegram
    {
        public int sender;
        public int reciever;
        public int message;
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
            return Math.Abs(t1.dispatchTime - t2.dispatchTime) < smallestDelay
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