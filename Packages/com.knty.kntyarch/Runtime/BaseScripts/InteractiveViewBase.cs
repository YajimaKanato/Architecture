using UnityEngine;

namespace KNTyArch.Runtime
{
    /// <summary>入力処理と表示処理を持ったクラスのベースクラス</summary>
    public abstract class InteractiveViewBase : MonoBehaviour, IView
    {
        /// <summary>データのHandle</summary>
        protected ModelHandle _definitionHandle;

        public abstract void Initialize();

        public void SetHandleID(int handleID)
        {
            _definitionHandle = new ModelHandle(handleID);
        }

        /// <summary>ライフサイクルを開始するメソッド</summary>
        public abstract void StartLifeCycle();

        /// <summary>ライフサイクルを停止するメソッド</summary>
        public abstract void StopLifeCycle();

        public abstract void SubscribeEvent();

        public abstract void UnsubscribeEvent();
    }

    /// <summary>入力処理と表示処理を持ったクラスのベースクラス</summary>
    /// <typeparam name="TDefinition">Definitionのデータ型</typeparam>
    public abstract class InteractiveViewBase<TDefinition> : InteractiveViewBase where TDefinition : DefinitionBase
    {
        public override sealed void StartLifeCycle()
        {
            if (_definitionHandle == null) throw new System.NullReferenceException(nameof(_definitionHandle));
            RuntimeStorage.TryRegister(_definitionHandle, typeof(TDefinition));
            ViewDataStorage.TryRegister(_definitionHandle, typeof(TDefinition));
        }

        public override sealed void StopLifeCycle()
        {
            if (_definitionHandle == null) throw new System.NullReferenceException(nameof(_definitionHandle));
            RuntimeStorage.TryUnregister(_definitionHandle);
            ViewDataStorage.TryUnregister(_definitionHandle);
        }
    }
}
