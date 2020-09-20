using System;
using System.Collections.Generic;
using System.Text;

namespace WildeWest
{
    class MinerGlobalState : State<Miner>
    {
        private static MinerGlobalState instance;
        public static MinerGlobalState Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MinerGlobalState();
                }
                return instance;
            }
        }

        public override void Enter(Miner miner)
        {
            
        }

        public override void Execute(Miner miner)
        {
            
        }

        public override void Exit(Miner miner)
        {
            
        }
    }
}
