using System;
using System.Collections.Generic;
using System.Text;

namespace WildeWest
{
    class Miner : BaseGameEntity
    {
        private int maxGoldCapacity = 3;
        private int thirstLevelForSaloon = 5;

        private StateMachine<Miner> stateMachine;

        State<Miner> currentState;
        public State<Miner>.Location CurrentLocation { get; set; }
        public string Name { get; set; }
        public int GoldCarried { get; set; }
        public int MoneyInBank { get; set; }
        public int Thirst { get; set; }
        public int Fatigue { get; set; }


        public Miner(int id) : base(id)
        {
            CurrentLocation = State<Miner>.Location.Home;
            GoldCarried = 0;
            MoneyInBank = 0;
            Thirst = 0;
            Fatigue = 0;

            stateMachine = new StateMachine<Miner>(this);
            stateMachine.SetCurrentState(GoHomeAndSleepTilRested.Instance);
            stateMachine.SetGlobalState(MinerGlobalState.Instance);
        }

        public override void Update()
        {
            Thirst += 1;
            stateMachine.Update();  
        }

        public void ChangeState(State<Miner> newState)
        {
            currentState.Exit(this);
            currentState = newState;
            currentState.Enter(this);
        }

        public void ChangeLocation(State<Miner>.Location location)
        {
            CurrentLocation = location;
        }

        public bool PocketIsFull()
        {
            if (GoldCarried >= maxGoldCapacity)
            {
                return true;
            }
            return false;
        }

        public bool Thirsty()
        {
            if (Thirst >= thirstLevelForSaloon)
            {
                return true;
            }
            return false;
        }

        public StateMachine<Miner> GetFSM()
        {
            return stateMachine;
        }
    }
}
