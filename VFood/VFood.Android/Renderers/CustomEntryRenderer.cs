using Android.Content;
using Android.Text;
using VFood.CustomViews;
using VFood.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace VFood.Droid.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            var customElement = Element as CustomEntry;

            if (customElement.MaxLength != null)
            {
                Control.SetFilters(new IInputFilter[] { new InputFilterLengthFilter(customElement.MaxLength.Value) });
            }
        }
    }
}