using Xamarin.Forms;

namespace VFood.CustomViews
{
    public class CustomEntry : Entry
    {
        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create(nameof(MaxLength), typeof(int?), typeof(FloatingActionButtonView), null);
        public int? MaxLength
        {
            get { return (int?)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }
    }
}
