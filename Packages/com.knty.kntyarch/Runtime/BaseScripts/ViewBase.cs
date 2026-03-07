using UnityEngine;
using System;

namespace KNTyArch.Runtime
{
    /// <summary>表示処理を持つクラス</summary>
    public abstract class ViewBase : MonoBehaviour, IView
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

    /// <summary>表示処理を持つクラス</summary>
    /// <typeparam name="TRuntime">対応するRuntimeの種類</typeparam>
    public abstract class ViewBase<TRuntime> : ViewBase where TRuntime : RuntimeBase
    {
        public override Type RuntimeType() => typeof(TRuntime);
    }
}
