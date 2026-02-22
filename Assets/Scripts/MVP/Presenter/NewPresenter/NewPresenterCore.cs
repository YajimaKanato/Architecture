using KNTy.MVP.Runtime;

public partial class NewPresenter : PresenterBase<NewView>
{
	ARuntimeModel _aRuntimeModel;
	BRuntimeModel _bRuntimeModel;
	CRuntimeModel _cRuntimeModel;
	DRuntimeModel _dRuntimeModel;

    public NewPresenter(ARuntimeModel aRuntimeModel,
		BRuntimeModel bRuntimeModel,
		CRuntimeModel cRuntimeModel,
		DRuntimeModel dRuntimeModel)
    {
		_aRuntimeModel = aRuntimeModel;
		_bRuntimeModel = bRuntimeModel;
		_cRuntimeModel = cRuntimeModel;
		_dRuntimeModel = dRuntimeModel;
    }
}