using System.IO;
using System.Windows.Media.Imaging;

namespace MapPresentor.Helpers
{
    public static class Helper
    {
        public static BitmapImage ConvertBytesToBitmapImage(byte[] bytes)
        {
            var bitmapImage = new BitmapImage();
            using (var stream = new MemoryStream(bytes))
            {
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = stream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
            }
            return bitmapImage;
        }
    }
}
