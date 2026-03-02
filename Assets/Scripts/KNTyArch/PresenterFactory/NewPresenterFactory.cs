using KNTyArch.Runtime;
using System.Collections.Generic;

public class NewScenePresenterFactory : IPresenterFactory
{
    readonly List<PresenterBase> _presenters = new();

    public void GeneratePresenter(RuntimeModelStorage storage_RM, ViewModelStorage storage_VM, IEventHub inputHub, IEventHub eventHub)
    {
        foreach (var presenter in _presenters)
        {
            presenter.Initialize(storage_RM, storage_VM, inputHub, eventHub);
        }
    }

    public void Dispose()
    {
        foreach(var  presenter in _presenters)
        {
            presenter.Dispose();
        }
    }
}