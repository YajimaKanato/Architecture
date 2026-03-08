using System;
using UnityEngine;

namespace KNTyArch.Runtime
{
    /// <summary>表示用に加工したデータを保持するクラスのベースクラス</summary>
    public class ViewDataBase : IDisposable
    {
        /// <summary>このクラスが削除されるときの処理を実行するメソッド</summary>
        public virtual void Dispose() { }
    }
}
