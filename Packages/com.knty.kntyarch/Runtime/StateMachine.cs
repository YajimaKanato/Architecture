namespace KNTyArch.Runtime
{
    /// <summary>View、InteractiveViewのステートを管理するクラス</summary>
    /// <typeparam name="TView">管理するView、InteractiveViewのデータ型</typeparam>
    public sealed class StateMachine<TView> where TView : IView
    {
        /// <summary>現在の状態</summary>
        IState<TView> _currentState;

        /// <summary>
        /// 状態を変更するメソッド
        /// </summary>
        /// <param name="newState">変更後の状態</param>
        public void ChangeState(IState<TView> newState)
        {
            if (_currentState != null && !_currentState.CanExit(newState)) return;
            _currentState?.Exit();
            _currentState = newState;
            _currentState?.Enter();
        }

        /// <summary>
        /// 現在の状態で継続的に行う処理を実行するメソッド
        /// </summary>
        public void Update()
        {
            _currentState?.Execute();
        }
    }
}
