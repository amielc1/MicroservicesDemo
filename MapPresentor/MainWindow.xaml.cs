using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.IO;
using System.Net.Http;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MapPresentor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            SetCurrentMisionMap();
            InitializeComponent();

            ConnectHub();
        }
        private async void ConnectHub()
        {
            //Set connection
            var builder = new HubConnectionBuilder()
                .WithUrl("https://localhost:51145/notification")
                .WithAutomaticReconnect();

            var connection = builder.Build();

            await connection.StartAsync();

            Console.WriteLine($"connection.State {connection.State}");

            connection.On<string>("MissionMapChanged",
               (mapname) =>
               {
                   Dispatcher.Invoke(() =>
                   {
                       SetCurrentMisionMap();
                   });
               });
        }


        private async void SetCurrentMisionMap()
        {
            string ApiUrl = "https://localhost:51141/api/MissionMap/GetCurrentMissionMap";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var str = await client.GetStringAsync(ApiUrl);
                    byte[] bytes = Convert.FromBase64String(str);
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.StreamSource = new MemoryStream(bytes);
                    bi.EndInit();
                    img_map.Source = bi;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
