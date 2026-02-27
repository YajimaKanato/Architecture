using KNTy.MVP.Runtime;
using System;

public class NewPresenter : PresenterBase
{
    public NewPresenter(RuntimeModelStorage storage_RM, ViewModelStorage storage_VM, IEventHub inputHub, IEventHub eventHub) : 
        base(storage_RM, storage_VM, inputHub, eventHub)
    {

    }

    public override void Dispose()
    {
        throw new NotImplementedException();
    }

    protected override void SubscribeInputHub()
    {
        throw new NotImplementedException();
    }
}