using KNTyArch.Runtime;
using System;

public class NewPresenter : PresenterBase
{
    public override void Initialize()
    {
        throw new NotImplementedException();
    }

    public override void Dispose()
    {
        throw new NotImplementedException();
    }

    protected override void SubscribeEvent()
    {
        throw new NotImplementedException();
    }

    protected override void UnsubscribeEvent()
    {
        EventHub.Unsubscribe(this);
    }
}