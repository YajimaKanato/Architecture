using UnityEngine;

namespace KNTyArch.Runtime
{
    /// <summary>表示処理を持つクラスのベースクラス</summary>
    public abstract class ViewBase : MonoBehaviour, IView
    {
        /// <summary>Definitionに対応したHandle</summary>
        protected ModelHandle _modelHandle;

        public abstract void Initialize();

        public void SetHandleID(int handleID)
        {
            _modelHandle = new ModelHandle(handleID);
        }

        public abstract void SubscribeEvent();

        public abstract void UnsubscribeEvent();
    }
}
