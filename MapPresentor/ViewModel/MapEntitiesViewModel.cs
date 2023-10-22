using MapPresentor.Helpers;
using MapPresentor.Models;
using MapPresentor.Services.Interfaces;
using MapPresentor.ViewModel.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Options;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MapPresentor.ViewModel;

public class MapEntitiesViewModel : BindableBase, IMapEntitiesViewModel
{
    private readonly AppSettings _settings;
    private readonly IMissionMapService _missionMapService;
    private MapEntityDto _currentMapEntity;
    private ObservableCollection<MapEntityDto> _mapEntities;
    private ObservableCollection<Ellipse> _ellipses;
    private ImageSource _currentMissionMap;

    public ImageSource CurrentMissionMap
    {
        get => _currentMissionMap;
        set => SetProperty(ref _currentMissionMap, value);
    }

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
    public ObservableCollection<Ellipse> Ellipses
    {
        get => _ellipses;
        set => SetProperty(ref _ellipses, value);
    }

    public ICommand CreateCommand { get; }

    public MapEntitiesViewModel(IMissionMapService missionMapService, IOptions<AppSettings> options)
    {
        _settings = options.Value;
        _missionMapService = missionMapService;
        SignalRManager signalRManager = new SignalRManager(_settings.HubUrl);
        signalRManager.connection.On<string>(_settings.ReciveMapEntityHubname, HandleReciveMapEntity);
        signalRManager.connection.On<string>(_settings.MissionMapChangedHubname, HandleMissionMapChanged);

        CreateCommand = new DelegateCommand(Create);
        MapEntities = new ObservableCollection<MapEntityDto>();
        Ellipses = new ObservableCollection<Ellipse>();
        CurrentMapEntity = new MapEntityDto();
        Init();
    }

    private async void Init()
    {
        await LoadCurrentMapImage();
    }
    private async void HandleMissionMapChanged(string mapName)
    {
        await LoadCurrentMapImage();
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
            AddEllipse(newMapEntity);
        }));
    }

    private async Task LoadCurrentMapImage()
    {
        var mapimagearr = await _missionMapService.GetCurrentMissionMap();
        var mapbitmap = Helper.ConvertBytesToBitmapImage(mapimagearr);
        CurrentMissionMap = mapbitmap;
    }

    private void AddEllipse(MapEntityDto point)
    {
        Ellipse ellipse = new Ellipse();
        ellipse.Fill = Brushes.OrangeRed;
        ellipse.Width = 10;
        ellipse.Height = 10;
        ellipse.StrokeThickness = 2;

        Canvas.SetLeft(ellipse, point.PointX);
        Canvas.SetTop(ellipse, point.PointY);

        Ellipses.Add(ellipse);  
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
        AddEllipse(newMapEntity);
        CurrentMapEntity = new MapEntityDto();
    }

}
