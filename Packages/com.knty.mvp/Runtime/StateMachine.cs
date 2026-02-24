namespace KNTy.MVP.Runtime
{
    public sealed class StateMachine
    {
        IState _currentState;

        public void ChangeState(IState newState)
        {
            if (_currentState != null && !_currentState.CanExit(newState)) return;
            _currentState?.Exit();
            _currentState = newState;
            _currentState?.Enter();
        }

        public void Update()
        {
            _currentState?.Execute();
        }
    }
}
