using Android.Content;
using Android.Support.Design.Widget;
using Xamarin.Forms;

namespace VFood.Droid.CustomViews
{
    public class AddFloatingButton : FloatingActionButton
    {
        public Command Command { get; set; }

        public AddFloatingButton(Context context) : base(context)
        {
            SetImageResource(Android.Resource.Drawable.IcInputAdd);

            Click += (sender, args) =>
            {
                Command?.Execute(null);
            };
        }
    }
}