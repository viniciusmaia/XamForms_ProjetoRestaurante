using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using Java.IO;
using Plugin.CurrentActivity;
using System.IO;
using VFood.Droid.Util;
using VFood.Util;
using Xamarin.Forms;

[assembly: Dependency(typeof(IconeImagemPadraoDroid))] 
namespace VFood.Droid.Util
{
    public class IconeImagemPadraoDroid : IIconeImagemPadrao
    {
        public byte[] GetIcone()
        {
            var icone = ContextCompat.GetDrawable(CrossCurrentActivity.Current.Activity, Resource.Drawable.ic_image_default);
            var iconeBitmap = ((BitmapDrawable)icone).Bitmap;
            using (var memoryStream = new MemoryStream())
            {
                iconeBitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}