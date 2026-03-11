using UnityEngine;

namespace KNTyArch.Runtime
{
    /// <summary>表示の役割を持つクラスに継承するインターフェース</summary>
    public interface IView
    {
        /// <summary>初期化メソッド</summary>
        void Initialize();

        /// <summary>HandleIDを設定するメソッド</summary>
        /// <param name="handleID">設定するID</param>
        void SetHandleID(int handleID);

        /// <summary>表示の処理を実行するためにイベントを購読するためのメソッド</summary>
        void SubscribeEvent();

        /// <summary>購読したイベントを解除するメソッド</summary>
        void UnsubscribeEvent();
    }
}
