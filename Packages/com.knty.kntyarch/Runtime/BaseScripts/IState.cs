namespace KNTyArch.Runtime
{
    /// <summary>対応するビューの状態管理をするクラスに継承するインターフェース</summary>
    /// <typeparam name="TView">ビューの種類</typeparam>
    public interface IState<TView> where TView : IView
    {
        /// <summary>
        /// 現在の状態を抜けることができるかを判定するメソッド
        /// </summary>
        /// <param name="newState">新しい状態</param>
        /// <returns>現在の状態を抜けることができるか</returns>
        bool CanExit(IState<TView> newState);

        /// <summary>
        /// 状態に入ったときの処理を行うメソッド
        /// </summary>
        void Enter();

        /// <summary>
        /// 現在の状態での継続的な処理を行うメソッド
        /// </summary>
        void Execute();

        /// <summary>
        /// 現在の状態を出る時の処理を行うメソッド
        /// </summary>
        void Exit();
    }
}
