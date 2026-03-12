using UnityEngine;

namespace KNTyArch.Runtime
{
    /// <summary>入力処理と表示処理を持ったクラスのベースクラス</summary>
    public abstract class InteractiveViewBase : MonoBehaviour, IView
    {
        /// <summary>データのHandle</summary>
        protected ModelHandle _modelHandle;

        public abstract void Initialize();

        public void SetHandleID(int handleID)
        {
            _modelHandle = new ModelHandle(handleID);
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
            if (_modelHandle == null) throw new System.NullReferenceException(nameof(_modelHandle));
            RuntimeStorage.TryRegister(_modelHandle, typeof(TDefinition));
            ViewDataStorage.TryRegister(_modelHandle, typeof(TDefinition));
        }

        public override sealed void StopLifeCycle()
        {
            if (_modelHandle == null) throw new System.NullReferenceException(nameof(_modelHandle));
            RuntimeStorage.TryUnregister(_modelHandle);
            ViewDataStorage.TryUnregister(_modelHandle);
        }
    }
}
