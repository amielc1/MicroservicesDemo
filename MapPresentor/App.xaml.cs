using MapPresentor.Services;
using MapPresentor.Services.Interfaces;
using MapPresentor.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace MapPresentor;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IHost host;
    public static IServiceProvider ServiceProvider { get; private set; }
    public App()
    {
        host = Host.CreateDefaultBuilder()  // Use default settings
                                            //new HostBuilder()          // Initialize an empty HostBuilder
                .ConfigureAppConfiguration((context, builder) =>
                {
                    // Add other configuration files...
                    //builder.AddJsonFile("appsettings.local.json", optional: true);
                }).ConfigureServices((context, services) =>
                {
                    ConfigureServices(context.Configuration, services);
                })
                .ConfigureLogging(logging =>
                {
                    // Add other loggers...
                })
                .Build();

        ServiceProvider = host.Services;
    }

    private void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        //services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
  
        // Register all ViewModels.
        services.AddTransient<IMissionMapService, MissionMapService>();
        services.AddTransient<IRESTCommand, RESTCommand>();

        services.AddSingleton<MapEntitiesViewModel>();
        services.AddSingleton<MissionMapViewModel>();

        // Register all the Windows of the applications.
        services.AddTransient<MainWindow>();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await host.StartAsync();

        var window = ServiceProvider.GetRequiredService<MainWindow>();
        window.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        using (host)
        {
            await host.StopAsync(TimeSpan.FromSeconds(5));
        }

        base.OnExit(e);
    }
}
