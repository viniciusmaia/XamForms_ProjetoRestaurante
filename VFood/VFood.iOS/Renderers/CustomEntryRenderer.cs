using Foundation;
using UIKit;
using VFood.CustomViews;
using VFood.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace VFood.iOS.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            var customElement = Element as CustomEntry;

            if (customElement.MaxLength != null)
            {
                Control.ShouldChangeCharacters = new UITextFieldChange(delegate (UITextField textField, NSRange range, string replacement)
                {
                    int newLength = textField.Text.Length + replacement.Length - (int)range.Length;
                    return newLength <= customElement.MaxLength.Value;
                });
            }            
        }
    }
}