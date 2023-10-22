using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;

namespace MapPresentor.ViewModel.Interfaces
{
    public interface IMissionMapViewModel
    {
        ImageSource CurrentMissionMap { get; set; }
        ICommand DeleteCommand { get; }
        ObservableCollection<string> Maps { get; set; }
        string SelectedMap { get; set; }
        ICommand SetCommand { get; }
    }
}