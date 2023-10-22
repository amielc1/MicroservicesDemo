using MapPresentor.ViewModel.Interfaces;
using System.Windows;

namespace MapPresentor;

public partial class MainWindow : Window
{
    public MainWindow(
        IViewModelLocator viewModelLocator)
    {
        InitializeComponent();
        this.DataContext = viewModelLocator;
    }
}
