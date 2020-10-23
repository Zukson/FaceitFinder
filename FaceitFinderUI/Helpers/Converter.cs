using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FaceitFinderUI.Helpers
{
    public class Converter : IConverter
    {
        public  BitmapImage ConvertBytesToBitmapImage(byte[] bytes)
        {
            using (var ms = new System.IO.MemoryStream(bytes))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }
        public byte[] ConvertBitmapImageToBytes(BitmapImage img)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(img));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
                return data;
            }
        }

        public BitmapImage GetImgByUrl(string url)
        {
            //WebClient client = new WebClient();
            // Stream stream =  client.OpenRead(url);
            BitmapImage bitmap;
            
            bitmap = new BitmapImage( new Uri(url));



            //stream.Flush();
            //stream.Close();
            //client.Dispose();
            return bitmap;
        }
    }

}


