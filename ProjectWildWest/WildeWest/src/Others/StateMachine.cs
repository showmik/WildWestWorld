using System;
using System.Collections.Generic;
using System.Text;

namespace WildeWest
{
    class StateMachine<Entity>
    {
        public Entity owner;
        public State<Entity> CurrentState { get; set; }
        public State<Entity> PreviousState { get; set; }
        public State<Entity> GlobalState { get; set; }

        public StateMachine(Entity owner)
        {
            this.owner = owner;
            CurrentState = null;
            PreviousState = null;
            GlobalState = null;
        }

        public void SetCurrentState(State<Entity> state)
        {
            CurrentState = state;
        }

        public void SetGlobalState(State<Entity> state)
        {
            GlobalState = state;
        }

        public void SetPreviousState(State<Entity> state)
        {
            PreviousState = state;
        }

        public void Update()
        {
            if (GlobalState != null)
            {
                GlobalState.Execute(owner);
            }

            if (CurrentState != null)
            {
                CurrentState.Execute(owner);
            }
        }

        public void ChangeState(State<Entity> newState)
        {
            PreviousState = CurrentState;
            CurrentState.Exit(owner);
            CurrentState = newState;
            CurrentState.Enter(owner);
        }

        public void RevertToPreviousState()
        {
            ChangeState(PreviousState);
        }

        public bool isInState(State<Entity> state)
        {
            if (state == CurrentState)
            {
                return true;
            }
            return false;
        }
    }
}
