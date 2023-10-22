namespace MapPresentor.ViewModel.Interfaces;

public interface IViewModelLocator
{
    public IMapEntitiesViewModel MapEntitiesViewModel { get; }
    public IMissionMapViewModel MissionMapViewModel { get; }

}
