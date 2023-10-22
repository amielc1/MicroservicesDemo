using MapPresentor.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;

namespace MapPresentor.ViewModel.Interfaces
{
    public interface IMapEntitiesViewModel
    {
        ICommand CreateCommand { get; }
        MapEntityDto CurrentMapEntity { get; set; }
        ImageSource CurrentMissionMap { get; set; }
        ObservableCollection<MapEntityDto> MapEntities { get; set; }
    }
}