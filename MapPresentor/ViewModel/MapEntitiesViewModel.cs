using MapPresentor.Models;
using MapPresentor.Services.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;

namespace MapPresentor.ViewModel;

public class MapEntitiesViewModel : BindableBase
{
    private readonly IMissionMapService _missionMapService;
    private MapEntityDto _currentMapEntity;
    private ObservableCollection<MapEntityDto> _mapEntities;

    public MapEntityDto CurrentMapEntity
    {
        get => _currentMapEntity;
        set => SetProperty(ref _currentMapEntity, value);
    }

    public ObservableCollection<MapEntityDto> MapEntities
    {
        get => _mapEntities;
        set => SetProperty(ref _mapEntities, value);
    }

    public ICommand CreateCommand { get; }

    public MapEntitiesViewModel(IMissionMapService missionMapService)
    {
        _missionMapService = missionMapService;
        SignalRManager signalRManager = new SignalRManager(AppSettings.HubUrl);
        signalRManager.connection.On<string>("ReciveMapEntity", HandleReciveMapEntity);
        CreateCommand = new DelegateCommand(Create);
        MapEntities = new ObservableCollection<MapEntityDto>();
        CurrentMapEntity = new MapEntityDto();
    }

    private void HandleReciveMapEntity(string entity)
    {
        var point = JsonSerializer.Deserialize<MapEntityDto>(entity);
        App.Current.Dispatcher.Invoke(new Action(() =>
        {
            MapEntityDto newMapEntity = new MapEntityDto
            {
                Title = point.Title,
                PointX = point.PointX,
                PointY = point.PointY
            };
            MapEntities.Add(newMapEntity);
        }));
    }

    private void Create()
    {
        MapEntityDto newMapEntity = new MapEntityDto
        {
            Title = CurrentMapEntity.Title,
            PointX = CurrentMapEntity.PointX,
            PointY = CurrentMapEntity.PointY
        };

        MapEntities.Add(newMapEntity);
        CurrentMapEntity = new MapEntityDto();
    }

}
