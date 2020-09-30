namespace Miscellaneous
{
    class Message
    {
        public enum MessageTypes
        {
            HiHoneyImHome,
            StewReady
        }

        public static string GetStringFromMessage(MessageTypes message)
        {
            switch (message)
            {
                case MessageTypes.HiHoneyImHome:
                    return "HiHoneyImHome";

                case MessageTypes.StewReady:
                    return "StewReady";

                default:
                    return "Not recognized!";
            }
        }
    }
}