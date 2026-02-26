namespace KNTy.MVP.Runtime
{
    public interface IState<TView> where TView : ViewBase
    {
        bool CanExit(IState<TView> newState);
        void Enter();
        void Execute();
        void Exit();
    }
}
