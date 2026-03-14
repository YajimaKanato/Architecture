using KNTyArch.Runtime;
using System;

public class NewPresenter : IPresenter
{
    NewInteractiveView _newIV;
    NewRuntime _newRuntime;

    public NewPresenter(NewInteractiveView newIV, NewDefinition newDefinition)
    {
        _newIV = newIV;
        _newRuntime = (NewRuntime)newDefinition.CreateRuntime();
        _newIV.BindPresenter(this);
    }
}