using System;

namespace KNTyArch.Runtime
{
    /// <summary>処理の流れを制御するクラスのベースクラス</summary>
    public abstract class PresenterBase : IDisposable
    {
        /// <summary>初期化メソッド</summary>
        public abstract void Initialize();

        /// <summary>このクラスが削除されるときの処理を実行するメソッド</summary>
        public abstract void Dispose();

        /// <summary>イベントを購読するメソッド</summary>
        protected abstract void SubscribeEvent();

        /// <summary>購読したイベントを解除するメソッド</summary>
        protected abstract void UnsubscribeEvent();
    }
}

