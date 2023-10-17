using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MapPresentor
{
    public class ImageManager
    {
        private readonly string apiUrl;
        private readonly Action<byte[]> onImageSet;

        public ImageManager(string apiUrl, Action<byte[]> onImageSet)
        {
            this.apiUrl = apiUrl;
            this.onImageSet = onImageSet;
        }

        public async Task SetCurrentMissionMapAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var imageBytes = await DownloadImageBytesAsync(client, apiUrl);
                    onImageSet?.Invoke(imageBytes);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public BitmapImage ConvertBytesToBitmapImage(byte[] bytes)
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(bytes);
            bitmapImage.EndInit();
            return bitmapImage;
        }

        private async Task<byte[]> DownloadImageBytesAsync(HttpClient client, string apiUrl)
        {
            var str = await client.GetStringAsync(apiUrl);
            return Convert.FromBase64String(str);
        }
    }
}
