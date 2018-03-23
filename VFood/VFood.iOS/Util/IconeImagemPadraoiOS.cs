using System;
using System.Runtime.InteropServices;
using UIKit;
using VFood.iOS.Util;
using VFood.Util;
using Xamarin.Forms;

[assembly: Dependency(typeof(DialogCarregamentoiOS))]
namespace VFood.iOS.Util
{
    public class IconeImagemPadraoiOS : IIconeImagemPadrao
    {
        public byte[] GetIcone()
        {
            var icone = UIImage.FromBundle("ic_image_default");

            byte[] imagemEmBytes = null;

            using (var imageData = icone.AsPNG())
            {
                imagemEmBytes = new byte[imageData.Length];
                Marshal.Copy(imageData.Bytes, imagemEmBytes, 0, Convert.ToInt32(imageData.Length));
            }

            return imagemEmBytes;
        }
    }
}