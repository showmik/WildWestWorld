namespace Miscellaneous
{
    internal struct Message
    {
        public enum MessageTypes
        {
            HiHoneyImHome,
            StewReady
        }

        public static string GetStringFromMessage(int message)
        {
            switch (message)
            {
                case (int)MessageTypes.HiHoneyImHome:
                    return "HiHoneyImHome";

                case (int)MessageTypes.StewReady:
                    return "StewReady";

                default:
                    return "Not recognized!";
            }
        }
    }
}