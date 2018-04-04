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

            var customEntry = Element as CustomEntry;

            if (customEntry.MaxLength != null)
            {
                Control.ShouldChangeCharacters = new UITextFieldChange(delegate (UITextField textField, NSRange range, string replacement)
                {
                    int newLength = textField.Text.Length + replacement.Length - (int)range.Length;
                    return newLength <= customEntry.MaxLength.Value;
                });
            }

            SetReturnType(customEntry);

            Control.ShouldReturn += (UITextField tf) =>
            {
                customEntry.InvokeCompleted();
                return true;
            };

        }

        private void SetReturnType(CustomEntry entry)
        {
            ReturnType type = entry.ReturnType;

            switch (type)
            {
                case ReturnType.Go:
                    Control.ReturnKeyType = UIReturnKeyType.Go;
                    break;
                case ReturnType.Next:
                    Control.ReturnKeyType = UIReturnKeyType.Next;
                    break;
                case ReturnType.Send:
                    Control.ReturnKeyType = UIReturnKeyType.Send;
                    break;
                case ReturnType.Search:
                    Control.ReturnKeyType = UIReturnKeyType.Search;
                    break;
                case ReturnType.Done:
                    Control.ReturnKeyType = UIReturnKeyType.Done;
                    break;
                default:
                    Control.ReturnKeyType = UIReturnKeyType.Default;
                    break;
            }
        }
    }
}