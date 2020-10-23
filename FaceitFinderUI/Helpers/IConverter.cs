using System.Windows.Media.Imaging;

namespace FaceitFinderUI.Helpers
{
    public interface IConverter
    {
        byte[] ConvertBitmapImageToBytes(BitmapImage img);
        BitmapImage ConvertBytesToBitmapImage(byte[] bytes);
        BitmapImage GetImgByUrl(string url);
    }
}