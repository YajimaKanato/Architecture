using UnityEngine;

namespace KNTyArch.Runtime
{
    /// <summary>責務を分離したクラスをつなげるクラス</summary>
    public abstract class SceneObjectFactoryBase : ScriptableObject
    {
        [SerializeField] protected int _id;

        /// <summary>
        /// シーン上のオブジェクトを作成するメソッド
        /// </summary>
        /// <returns>生成するシーン上のオブジェクト</returns>
        public abstract InteractiveViewBase CreateSceneObject();

        /// <summary>
        /// シーン上のオブジェクトを作成するメソッド
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>生成するシーン上のオブジェクト</returns>
        public abstract InteractiveViewBase CreateSceneObject(int id);
    }
}
