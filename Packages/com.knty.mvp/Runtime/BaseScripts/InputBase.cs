using System;
using UnityEngine;

namespace KNTyArch.Runtime
{
    /// <summary>入力処理を行うクラス</summary>
    public abstract class InputBase : MonoBehaviour
    {
        /// <summary>ID</summary>
        [SerializeField] protected string _id;

        /// <summary>入力のハブ</summary>
        protected IEventHub _inputHub;

        /// <summary>IDを取得するプロパティ</summary>
        public string ID => _id;

        /// <summary>モデルの型を取得するメソッド</summary>
        /// <returns>モデルの型</returns>
        public abstract Type ModelType();

        /// <summary>入力のハブを設定するメソッド</summary>
        /// <param name="inputHub">入力のハブ</param>
        public void SetInputHub(IEventHub inputHub) => _inputHub = inputHub;
    }

    /// <summary>入力処理を行うクラス</summary>
    /// <typeparam name="TRuntimeModel">対応するモデルの種類</typeparam>
    public abstract class InputBase<TRuntimeModel> : InputBase where TRuntimeModel : RuntimeBase
    {
        public override Type ModelType() => typeof(TRuntimeModel);
    }
}
