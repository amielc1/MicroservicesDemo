using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MapPresentor
{
    public partial class MainWindow : Window
    {
        private const string GetCurrentMissionMapUrl = "https://localhost:51141/api/MissionMap/GetCurrentMissionMap";
        private const string GetAllMapsUrl = "http://localhost:51142/api/MapRepository/GetAllMaps";
        private const string HubUrl = "https://localhost:51145/notification";
        private const string SetMissionMapUrl = "http://localhost:51142/api/MissionMap/SetMissionMap";
        private const string DeleteMapUrl = "http://localhost:51142/api/MapRepository/DeleteMap";
        private readonly SignalRManager signalRManager;
        private readonly ImageManager imageManager;


        public MainWindow()
        {
            InitializeComponent();
            LoadMapsIntoLisbox();
            imageManager = new ImageManager(GetCurrentMissionMapUrl, OnImageSet);
            signalRManager = new SignalRManager(HubUrl);
            ConnectHub();
            SetCurrentMissionMap();
        }

        private async Task SendPostRequest(string ApiUrl, string data)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    // Prepare the content for the POST request
                    StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                    // Make the POST request
                    HttpResponseMessage response = await client.PostAsync(ApiUrl, content);

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Handle the successful response
                        string responseBody = await response.Content.ReadAsStringAsync();
                        //MessageBox.Show($"POST request successful. Response: {responseBody}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        // Handle non-success status code, if needed.
                        MessageBox.Show($"POST request failed. Status code: {response.StatusCode}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task LoadMapsIntoLisbox()
        {
            var maps = await LoadMapsFromApi();
            Dispatcher.BeginInvoke(() => { lst_maps.ItemsSource = maps; });
        }

        private async Task<List<string>> LoadMapsFromApi()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(GetAllMapsUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var maps = JsonConvert.DeserializeObject<List<string>>(content);
                        return maps;
                    }
                    return new List<string>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }


        private void ConnectHub()
        {
            signalRManager.StartConnection(() => Dispatcher.Invoke(() => SetCurrentMissionMap()));
        }
        private async void SetCurrentMissionMap()
        {
            await imageManager.SetCurrentMissionMapAsync();
        }

        private void OnImageSet(byte[] imageBytes)
        {
            var bitmapImage = imageManager.ConvertBytesToBitmapImage(imageBytes);
            img_map.Source = bitmapImage;
        }

        private async void btn_set_Click(object sender, RoutedEventArgs e)
        {
            var maptoset = (string)lst_maps.SelectedValue;
            await SendPostRequest(SetMissionMapUrl, maptoset);

        }

        private async void btn_del_Click(object sender, RoutedEventArgs e)
        {
            var maptoset = (string)lst_maps.SelectedValue;
            await SendPostRequest(DeleteMapUrl, maptoset);
            LoadMapsIntoLisbox();
        }
    }
}
