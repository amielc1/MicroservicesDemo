using MapPresentor.Services;
using MapPresentor.Services.Interfaces;
using Prism.Ioc;
using Prism.Unity;
using System.Windows;

namespace MapPresentor
{
    public class Bootstrapper : PrismBootstrapper
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IMissionMapService, MissionMapService>();
            containerRegistry.Register<IRESTCommand, RESTCommand>(); 
        }
    }
}
