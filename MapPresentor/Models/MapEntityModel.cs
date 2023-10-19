using Prism.Mvvm;
namespace MapPresentor.Models;

public class MapEntityModel : BindableBase
{
    private string _title = "New Point";
    private double _xPos = 0.0;
    private double _yPos = 0.0;

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public double XPos
    {
        get => _xPos;
        set => SetProperty(ref _xPos, value);
    }

    public double YPos
    {
        get => _yPos;
        set => SetProperty(ref _yPos, value);
    }
}
