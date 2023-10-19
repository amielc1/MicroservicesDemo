using MapPresentor.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MapPresentor.Services;

internal class RESTCommand : IRESTCommand
{
    public async Task<string> SendGetRequest(string ApiUrl)
    {
        string content = string.Empty;
        try
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(ApiUrl);

                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();
                }
                return content;
            }
        }
        catch (Exception ex)
        {
            //todo extract log 
            //MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            throw;
        }
    }

    public async Task SendPostRequest(string ApiUrl, string data)
    {
        try
        {

            //todo inject logger 

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
                    //MessageBox.Show($"POST request failed. Status code: {response.StatusCode}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        catch (Exception ex)
        {
            //MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
