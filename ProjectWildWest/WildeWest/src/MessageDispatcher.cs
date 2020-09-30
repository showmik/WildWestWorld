using System;
using System.Collections.Generic;
using System.Linq;

namespace WildeWest
{
    internal class MessageDispatcher
    {
        public Queue<Telegram> priorityQ;
        private static MessageDispatcher instance;

        public static MessageDispatcher Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MessageDispatcher();
                }
                return instance;
            }
        }

        private MessageDispatcher()
        {
            priorityQ = new Queue<Telegram>();
        }

        //---------------------------- Discharge ---------------------------
        // This method is utilized by DispatchMessage or DispatchDelayedMessages.
        // This method calls the message handling member function of the receiving
        // entity, pReceiver, with the newly created telegram.
        //------------------------------------------------------------------------

        private void Discharge(BaseGameEntity reciever, Telegram message)
        {
            if (!reciever.HandleMessage(message))
            {
                Console.WriteLine("Message not handled.");
            }
        }

        //---------------------------- DispatchMessage ---------------------------
        //  Given a message, a receiver, a sender and any time delay , this function
        //  routes the message to the correct agent (if no delay) or stores
        //  in the message queue to be dispatched at the correct time.
        //------------------------------------------------------------------------

        public void DispatchMessage(double delay, int sender, int reciever, int message)
        {
            BaseGameEntity pSender = EntityManager.Instance.GetEntityFromID(sender);
            BaseGameEntity pReciever = EntityManager.Instance.GetEntityFromID(reciever);

            if (pReciever == null)
            {
                Console.WriteLine($"Warning! No reciever with ID of {reciever} found.");
                return;
            }

            Telegram telegram = new Telegram(0, sender, reciever, message);

            if (delay <= 0.0f)
            {
                Console.WriteLine($"\nInstant telegram dispatched at time: {DateTime.Now.TimeOfDay} by {pSender.Name} for {pReciever.Name}.Message is {message}");
                Discharge(pReciever, telegram);
            }
            else
            {
                double currentTime = DateTime.Now.TimeOfDay.TotalSeconds;
                telegram.dispatchTime = currentTime + delay;

                priorityQ.Enqueue(telegram);
                Console.WriteLine($"\nDelayed telegram from {pSender.Name} recorded at time {DateTime.Now.TimeOfDay} for {pReciever.Name}" +
                                  $"Message is {message}");
            }
        }

        //---------------------- DispatchDelayedMessages -------------------------
        //  This function dispatches any telegrams with a timestamp that has
        //  expired. Any dispatched telegrams are removed from the queue.
        //------------------------------------------------------------------------

        public void DispatchDelayedMessage()
        {
            double currentTime = DateTime.Now.TimeOfDay.TotalSeconds;

            while ((priorityQ.Count != 0)
                && (priorityQ.First().dispatchTime < currentTime)
                && (priorityQ.First().dispatchTime > 0))
            {
                Telegram telegram = priorityQ.First();
                BaseGameEntity pReciever = EntityManager.Instance.GetEntityFromID(telegram.reciever);
                Console.WriteLine($"Queued telegram ready for dispatch: Sent to {pReciever.Name}, Message is {telegram.message}");
                Discharge(pReciever, telegram);

                priorityQ.Dequeue();
            }
        }
    }
}