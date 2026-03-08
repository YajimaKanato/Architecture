using UnityEngine;
using System;

namespace KNTyArch.Runtime
{
    /// <summary>表示処理を持つクラスのベースクラス</summary>
    public abstract class ViewBase : MonoBehaviour, IView
    {
        /// <summary>このクラスが対応するデータのID</summary>
        [SerializeField, Tooltip("このクラスが対応するデータのID")] protected string _id;

        /// <summary>IDを取得するプロパティ</summary>
        public string ID => _id;

        /// <summary>Runtimeのデータ型を取得するメソッド</summary>
        /// <returns>Runtimeのデータ型</returns>
        public abstract Type RuntimeType();

        /// <summary>イベントを購読するメソッド</summary>
        public abstract void SubscribeEvent();
    }

    /// <summary>表示処理を持つクラスのベースクラス</summary>
    /// <typeparam name="TRuntime">Runtimeのデータ型</typeparam>
    public abstract class ViewBase<TRuntime> : ViewBase where TRuntime : RuntimeBase
    {
        public override Type RuntimeType() => typeof(TRuntime);
    }
}
