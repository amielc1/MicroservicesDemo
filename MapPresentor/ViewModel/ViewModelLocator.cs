using Microsoft.Extensions.DependencyInjection;

namespace MapPresentor.ViewModel;

public class ViewModelLocator
{
    public MapEntitiesViewModel MapEntitiesViewModel => App.ServiceProvider.GetRequiredService<MapEntitiesViewModel>();
    public MissionMapViewModel MissionMapViewModel => App.ServiceProvider.GetRequiredService<MissionMapViewModel>();

}
