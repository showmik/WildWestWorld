using System;

namespace WildeWest
{
    internal class Clock
    {
        private static TimeSpan startTime;

        public static double CurrentTime
        {
            get
            {
                TimeSpan elapsedTime = DateTime.Now.TimeOfDay - startTime;
                return (double)elapsedTime.TotalSeconds;
            }
        }

        public Clock()
        {
            startTime = DateTime.Now.TimeOfDay;
        }
    }
}