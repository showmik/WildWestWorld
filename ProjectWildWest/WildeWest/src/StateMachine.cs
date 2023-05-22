//------------------------------------------------------------------------
//
//  Name:   StateMachine.cs
//
//  Desc:   State machine class. Inherit from this class and create some
//          states to give your agents FSM functionality
//
//------------------------------------------------------------------------

namespace WildeWest
{
    internal class StateMachine<Entity>
    {
        private Entity _owner;

        // A reference to the agent that owns this instance.
        public Entity Owner => _owner;

        // The current state of the agent.
        public State<Entity> CurrentState { get; set; }

        // A record of the last state the agent was in.
        public State<Entity> PreviousState { get; set; }

        // This is called every time the FSM is updated.
        public State<Entity> GlobalState { get; set; }

        public StateMachine(Entity owner)
        {
            _owner = owner;
            CurrentState = null;
            PreviousState = null;
            GlobalState = null;
        }

        public void SetCurrentState(State<Entity> state) => CurrentState = state;

        public void SetGlobalState(State<Entity> state) => GlobalState = state;

        public void SetPreviousState(State<Entity> state) => PreviousState = state;

        // Call this to update the FSM.
        public void Update()
        {
            // If a global state exists, call its execute method, else do nothing.
            GlobalState?.Execute(Owner);

            // Same for the current state.
            CurrentState?.Execute(Owner);
        }

        internal bool HandleMessage(Telegram message)
        {
            // First see if the current state is valid and that it can handle the message.
            if ((CurrentState != null) && CurrentState.OnMessage(Owner, message))
            {
                return true;
            }

            // If not, and if a global state has been implemented, send the message to the global state.
            if ((GlobalState != null) && GlobalState.OnMessage(Owner, message))
            {
                return true;
            }

            return false;
        }

        // Change to a new state.
        public void ChangeState(State<Entity> newState)
        {
            // Keep a record of the previous state.
            PreviousState = CurrentState;

            // Call the exit method of the existing state.
            CurrentState.Exit(Owner);

            // Change state to the new state.
            CurrentState = newState;

            // Call the entry method of the new state.
            CurrentState.Enter(Owner);
        }

        // Change state back to the previous state.
        public void RevertToPreviousState() => ChangeState(PreviousState);

        public bool IsInState(State<Entity> state) => state == CurrentState;
    }
}