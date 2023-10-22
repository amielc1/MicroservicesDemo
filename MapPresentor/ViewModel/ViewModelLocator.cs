using MapPresentor.ViewModel.Interfaces;

namespace MapPresentor.ViewModel;

internal class ViewModelLocator : IViewModelLocator
{
    private readonly IMapEntitiesViewModel _mapEntitiesViewModel;
    private readonly IMissionMapViewModel _missionMapViewModel;
    public ViewModelLocator(IMapEntitiesViewModel mapEntitiesViewModel, IMissionMapViewModel missionMapViewModel)
    {
        _mapEntitiesViewModel = mapEntitiesViewModel;
        _missionMapViewModel = missionMapViewModel;
    }

    public IMapEntitiesViewModel MapEntitiesViewModel { get => _mapEntitiesViewModel; }
    public IMissionMapViewModel MissionMapViewModel { get => _missionMapViewModel; }
}
