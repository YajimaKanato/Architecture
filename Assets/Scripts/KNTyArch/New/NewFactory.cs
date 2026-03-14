using KNTyArch.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFactory", menuName = "Factory/NewFactory")]
public class NewFactory : SceneObjectFactoryBase
{
    [SerializeField] NewDefinition _newDefinition;
    [SerializeField] NewInteractiveView _newIV;

    public override InteractiveViewBase CreateSceneObject()
    {
        var p = new NewPresenter(_newIV, _newDefinition);
        return _newIV;
    }

    public override InteractiveViewBase CreateSceneObject(int id)
    {
        _id = id;
        var p = new NewPresenter(_newIV, _newDefinition);
        return _newIV;
    }
}