using MapPresentor.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MapPresentor.ViewModel.Interfaces
{
    public interface IMapEntitiesViewModel
    {
        ICommand CreateCommand { get; }
        MapEntityDto CurrentMapEntity { get; set; }
        ObservableCollection<MapEntityDto> MapEntities { get; set; }
    }
}