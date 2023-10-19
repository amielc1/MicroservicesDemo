using Prism.Ioc;
using System.Windows;

namespace MapPresentor
{
    public partial class MainWindow : Window
    {
        IContainerExtension _container;


        public MainWindow(IContainerExtension container)
        {
            InitializeComponent();
            _container = container;
        }
    }
}
