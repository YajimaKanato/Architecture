using System;

namespace KNTyArch.Runtime
{
    /// <summary>プレゼンター生成処理を実装するクラスに継承するインターフェース</summary>
    public interface IPresenterFactory : IDisposable
    {
        /// <summary>
        /// プレゼンター生成を行うメソッド
        /// </summary>
        /// <param name="storage_RM">ランタイムモデルの保管庫</param>
        /// <param name="storage_VM">ビューモデルの保管庫</param>
        /// <param name="inputHub">入力のハブ</param>
        /// <param name="eventHub">イベントのハブ</param>
        void GeneratePresenter(RuntimeModelStorage storage_RM, ViewModelStorage storage_VM, IEventHub inputHub, IEventHub eventHub);
    }
}
