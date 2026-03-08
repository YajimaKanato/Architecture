using UnityEngine;
using System;

namespace KNTyArch.Runtime
{
    /// <summary>初期データのベースクラス</summary>
    public abstract class DefinitionBase : ScriptableObject
    {
        /// <summary>Runtimeのデータ型を返すメソッド</summary>
        /// <returns>Runtimeのデータ型</returns>
        public abstract Type GetRuntimeType();

        /// <summary>ViewDataのデータ型を返すメソッド</summary>
        /// <returns>ViewDataのデータ型</returns>
        public abstract Type GetViewDataType();

        /// <summary>Runtimeを生成するメソッド</summary>
        /// <returns>生成したRuntime</returns>
        public abstract RuntimeBase CreateRuntime();

        /// <summary>ViewDataを生成するメソッド</summary>
        /// <returns>生成したViewData</returns>
        public abstract ViewDataBase CreateViewData();
    }

    /// <summary>初期データのベースクラス</summary>
    /// <typeparam name="TRuntime">Runtimeのデータ型</typeparam>
    /// <typeparam name="TViewData">ViewDataのデータ型</typeparam>
    public abstract class DefinitionBase<TRuntime, TViewData> : DefinitionBase where TRuntime : RuntimeBase where TViewData : ViewDataBase
    {
        public sealed override Type GetRuntimeType() => typeof(TRuntime);

        public sealed override Type GetViewDataType() => typeof(TViewData);

        public sealed override RuntimeBase CreateRuntime()
        {
            return CreateTypedRuntime();
        }

        public sealed override ViewDataBase CreateViewData()
        {
            return CreateTypedViewData();
        }

        /// <summary>TRuntime型のインスタンスを生成するメソッド</summary>
        /// <returns>TRuntime型のインスタンス</returns>
        public abstract TRuntime CreateTypedRuntime();

        /// <summary>TViewData型のインスタンスを生成するメソッド</summary>
        /// <returns>TViewData型のインスタンス</returns>
        public abstract TViewData CreateTypedViewData();
    }
}
