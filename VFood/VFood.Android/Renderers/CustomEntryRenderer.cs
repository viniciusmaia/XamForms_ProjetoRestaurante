using Android.Content;
using Android.Text;
using Android.Views.InputMethods;
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

            var customEntry = Element as CustomEntry;

            if (customEntry.MaxLength != null)
            {
                Control.SetFilters(new IInputFilter[] { new InputFilterLengthFilter(customEntry.MaxLength.Value) });
            }


        }

        private void SetReturnType(CustomEntry entry)
        {
            ReturnType type = entry.ReturnType;

            switch (type)
            {
                case ReturnType.Go:
                    Control.ImeOptions = ImeAction.Go;
                    //Control.SetImeActionLabel(Context.GetText(Resource.String.textIr), ImeAction.Go);
                    break;
                case ReturnType.Next:
                    Control.ImeOptions = ImeAction.Next;
                    //Control.SetImeActionLabel(Context.GetText(Resource.String.textProximo), ImeAction.Next);
                    break;
                case ReturnType.Send:
                    Control.ImeOptions = ImeAction.Send;
                    //Control.SetImeActionLabel(Context.GetText(Resource.String.textEnviar), ImeAction.Send);
                    break;
                case ReturnType.Search:
                    Control.ImeOptions = ImeAction.Search;
                    //Control.SetImeActionLabel(Context.GetText(Resource.String.textBuscar), ImeAction.Search);
                    break;
                default:
                    Control.ImeOptions = ImeAction.Done;
                    //Control.SetImeActionLabel("Done", ImeAction.Done);
                    break;
            }
        }
    }
}