using System;

namespace KNTyArch.Runtime
{
    /// <summary>プレゼンター生成処理を実装するクラスに継承するインターフェース</summary>
    public interface IPresenterFactory : IDisposable
    {
        /// <summary>
        /// プレゼンター生成を行うメソッド
        /// </summary>
        void GeneratePresenter();
    }
}
