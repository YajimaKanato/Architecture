using System;
using UnityEngine;

namespace KNTyArch.Runtime
{
    /// <summary>入力処理と表示処理を持ったクラスのベースクラス</summary>
    public abstract class InteractiveViewBase : MonoBehaviour, IView
    {
        /// <summary>ID</summary>
        [SerializeField] protected string _id;

        /// <summary>IDを取得するプロパティ</summary>
        public string ID => _id;

        /// <summary>Runtimeのデータ型を取得するメソッド</summary>
        /// <returns>Runtimeのデータ型</returns>
        public abstract Type RuntimeType();

        /// <summary>イベントを購読するメソッド</summary>
        public abstract void SubscribeEvent();
    }

    /// <summary>入力処理と表示処理を持ったクラスのベースクラス</summary>
    /// <typeparam name="TRuntime">Runtimeのデータ型</typeparam>
    public abstract class InteractiveViewBase<TRuntime> : InteractiveViewBase where TRuntime : RuntimeBase
    {
        public override Type RuntimeType() => typeof(TRuntime);
    }
}
