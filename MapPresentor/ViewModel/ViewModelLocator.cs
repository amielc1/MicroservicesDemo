using MapPresentor.ViewModel.Interfaces;

namespace MapPresentor.ViewModel;

public class ViewModelLocator
{
    public IMapEntitiesViewModel MapEntitiesViewModel { get; set; }
    public IMissionMapViewModel MissionMapViewModel { get; set; }

}
