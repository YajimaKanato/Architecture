using System;

namespace KNTyArch.Runtime
{
    /// <summary>ランタイム中に変化するデータのベースクラス</summary>
    public abstract class RuntimeBase : IDisposable
    {
        /// <summary>このクラスが削除されるときの処理を実行するメソッド</summary>
        public virtual void Dispose() { }
    }
}
