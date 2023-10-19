using MapPresentor.Services;
using MapPresentor.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging; 
using Microsoft.AspNetCore.SignalR.Client;
namespace MapPresentor.ViewModel;

public class MissionMapViewModel : BindableBase
{ 
    private IMissionMapService _missionMapService;
    private ObservableCollection<string> _maps;
    private string _selectedMap;
    private ImageSource _currentMissionMap;

    public ImageSource CurrentMissionMap
    {
        get => _currentMissionMap;
        set => SetProperty(ref _currentMissionMap, value);
    }

    public ObservableCollection<string> Maps
    {
        get => _maps;
        set => SetProperty(ref _maps, value);
    }

    public string SelectedMap
    {
        get => _selectedMap;
        set => SetProperty(ref _selectedMap, value);
    }

    public ICommand SetCommand { get; }
    public ICommand DeleteCommand { get; }

    public MissionMapViewModel()
    {

        SignalRManager signalRManager = new SignalRManager(AppSettings.HubUrl);
        signalRManager.connection.On<string>("MissionMapChanged", HandleMissionMapChanged); 
        _missionMapService = new MissionMapService(new RESTCommand());
        Maps = new ObservableCollection<string>();
        SetCommand = new DelegateCommand(Set);
        DeleteCommand = new DelegateCommand(Delete);
        Init();
    }

    private async void Init()
    {
        await LoadMaps();
        await LoadCurrentMapImage();
    }
    private async void HandleMissionMapChanged(string mapName)
    {
        await LoadCurrentMapImage();
    }
    private void Set()
    {
        _missionMapService.SetMissionMap(SelectedMap);
    }

    private async void Delete()
    {
        await _missionMapService.DeleteMap(SelectedMap);
        await LoadMaps();
    }

    private async Task LoadMaps()
    {
        var maps = await _missionMapService.LoadMaps();
        Maps = new ObservableCollection<string>(maps);
    }

    private async Task LoadCurrentMapImage()
    {
        var mapimagearr = await _missionMapService.GetCurrentMissionMap();
        var mapbitmap = ConvertBytesToBitmapImage(mapimagearr);
        CurrentMissionMap = mapbitmap;

    }

    public BitmapImage ConvertBytesToBitmapImage(byte[] bytes)
    {
        var bitmapImage = new BitmapImage();
        using (var stream = new MemoryStream(bytes))
        {
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = stream;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
            bitmapImage.Freeze();
        }
        return bitmapImage;
    }
}
