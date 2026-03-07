using System;
using UnityEngine;

namespace KNTyArch.Runtime
{
    /// <summary>入力処理と表示処理を持ったクラス</summary>
    public abstract class InteractiveViewBase : MonoBehaviour, IView
    {
        /// <summary>ID</summary>
        [SerializeField] protected string _id;

        /// <summary>IDを取得するプロパティ</summary>
        public string ID => _id;

        /// <summary>Runtimeの型を取得するメソッド</summary>
        /// <returns>Runtimeの型</returns>
        public abstract Type RuntimeType();

        /// <summary>イベントを購読するメソッド</summary>
        public abstract void SubscribeEvent();
    }

    /// <summary>入力処理と表示処理を持ったクラス</summary>
    /// <typeparam name="TRuntime">対応するRuntimeの種類</typeparam>
    public abstract class InteractiveViewBase<TRuntime> : InteractiveViewBase where TRuntime : RuntimeBase
    {
        public override Type RuntimeType() => typeof(TRuntime);
    }
}
