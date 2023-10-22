using MapPresentor.ViewModel;
using MapPresentor.ViewModel.Interfaces;
using System.Windows;

namespace MapPresentor
{
    public partial class MainWindow : Window
    {
        public MainWindow(
            IMapEntitiesViewModel mapEntitiesViewModel,
            IMissionMapViewModel missionMapViewModel)
        {
            InitializeComponent();
            this.DataContext = new ViewModelLocator()
            {
                MapEntitiesViewModel = mapEntitiesViewModel,
                MissionMapViewModel = missionMapViewModel
            };
        }
    }
}
