using UnityEngine;

namespace KNTyArch.Runtime
{
    /// <summary>表示の役割を持つクラスに継承するインターフェース</summary>
    public interface IView
    {
        /// <summary>表示の処理を実行するためにイベントを購読するためのメソッド</summary>
        void SubscribeEvent();

        /// <summary>購読したイベントを解除するメソッド</summary>
        void UnsubscribeEvent();
    }
}
