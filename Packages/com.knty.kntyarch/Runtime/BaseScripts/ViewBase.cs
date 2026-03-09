using UnityEngine;

namespace KNTyArch.Runtime
{
    /// <summary>表示処理を持つクラスのベースクラス</summary>
    public abstract class ViewBase : MonoBehaviour, IView
    {
        /// <summary>初期化メソッド</summary>
        public abstract void Initialize();

        /// <summary>イベントを購読するメソッド</summary>
        public abstract void SubscribeEvent();
    }

    /// <summary>表示処理を持つクラスのベースクラス</summary>
    /// <typeparam name="TDefinition">Definitionのデータ型</typeparam>
    public abstract class ViewBase<TDefinition> : ViewBase where TDefinition : DefinitionBase
    {
        /// <summary>Definitionに対応したHandle</summary>
        protected ModelHandle<TDefinition> _definitionHandle;
    }
}
