using UnityEngine;

namespace KNTyArch.Runtime
{
    /// <summary>入力処理と表示処理を持ったクラスのベースクラス</summary>
    public abstract class InteractiveViewBase : MonoBehaviour, IView
    {
        /// <summary>初期化メソッド</summary>
        public abstract void Initialize();

        /// <summary>ModelHandleの持つIDパラメータを設定するメソッド</summary>
        /// <param name="handleID">IDとして設定する整数値</param>
        public abstract void SetHandleID(int handleID);

        /// <summary>イベントを購読するメソッド</summary>
        public abstract void SubscribeEvent();
    }

    /// <summary>入力処理と表示処理を持ったクラスのベースクラス</summary>
    /// <typeparam name="TDefinition">Definitionのデータ型</typeparam>
    public abstract class InteractiveViewBase<TDefinition> : InteractiveViewBase where TDefinition : DefinitionBase
    {
        /// <summary>Definitionに対応したHandle</summary>
        protected ModelHandle<TDefinition> _definitionHandle;
    }
}
