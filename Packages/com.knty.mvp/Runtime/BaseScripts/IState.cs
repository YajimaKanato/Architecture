namespace KNTy.MVP.Runtime
{
    public interface IState
    {
        bool CanExit(IState newState);
        void Enter();
        void Execute();
        void Exit();
    }
}
