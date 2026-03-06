using KNTyArch.Runtime;
using System.Collections.Generic;

public class NewScenePresenterFactory : IPresenterFactory
{
    readonly List<PresenterBase> _presenters = new();

    public void GeneratePresenter()
    {
        foreach (var presenter in _presenters)
        {
            presenter.Initialize();
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