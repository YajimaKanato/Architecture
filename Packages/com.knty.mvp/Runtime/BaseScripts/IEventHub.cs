using System;

namespace KNTyArch.Runtime
{
    /// <summary>イベントを集約させるクラスに継承するインターフェース</summary>
    public interface IEventHub
    {
        /// <summary>
        /// イベントのトークンに応じて登録されているアクションを実行するメソッド
        /// </summary>
        /// <typeparam name="TEvent">ITokenを継承したトークンの種類</typeparam>
        /// <param name="e">イベントのトークン</param>
        void Publish<TEvent>(TEvent e) where TEvent : struct, IToken;

        /// <summary>
        /// トークンに対応したイベントを購読してアクションを登録するメソッド
        /// </summary>
        /// <typeparam name="TEvent">ITokenを継承したトークンの種類</typeparam>
        /// <param name="handler">登録したいアクション</param>
        /// <returns>登録解除の処理</returns>
        IDisposable Subscribe<TEvent>(Action<TEvent> handler) where TEvent : struct, IToken;
    }
}
