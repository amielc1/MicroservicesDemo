using MapEntitiesService.Core.Models;
using MapPresentor.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MapPresentor.ViewModel;

public class MapEntitiesViewModel : BindableBase
{ 
    private MapEntityModel _currentMapEntity;
    private ObservableCollection<MapEntityModel> _mapEntities;

    public MapEntityModel CurrentMapEntity
    {
        get => _currentMapEntity;
        set => SetProperty(ref _currentMapEntity, value);
    }

    public ObservableCollection<MapEntityModel> MapEntities
    {
        get => _mapEntities;
        set => SetProperty(ref _mapEntities, value);
    }

    public ICommand CreateCommand { get; }

    public MapEntitiesViewModel()
    {
        SignalRManager signalRManager = new SignalRManager(AppSettings.HubUrl);

        signalRManager.connection.On<MapEntityDto>("ReciveMapEntity", HandleReciveMapEntity);
        CreateCommand = new DelegateCommand(Create);
        MapEntities = new ObservableCollection<MapEntityModel>();
        CurrentMapEntity = new MapEntityModel();
    }

    private void HandleReciveMapEntity(MapEntityDto point)
    {
        App.Current.Dispatcher.Invoke(new Action(() =>
        {
            MapEntityModel newMapEntity = new MapEntityModel
            {
                Title = point.Tile,
                XPos = point.PointX,
                YPos = point.PointY
            };
            MapEntities.Add(newMapEntity);
        }));
    }

    private void Create()
    {
        MapEntityModel newMapEntity = new MapEntityModel
        {
            Title = CurrentMapEntity.Title,
            XPos = CurrentMapEntity.XPos,
            YPos = CurrentMapEntity.YPos
        };

        MapEntities.Add(newMapEntity);
        CurrentMapEntity = new MapEntityModel();
    }

}
