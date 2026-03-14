using UnityEngine;

namespace KNTyArch.Runtime
{
    /// <summary>入力処理と表示処理を持ったクラスのベースクラス</summary>
    public abstract class InteractiveViewBase : MonoBehaviour, IView
    {
        public abstract void BindPresenter(IPresenter presenter);

        public abstract void SubscribeEvent();

        public abstract void UnsubscribeEvent();
    }
}
