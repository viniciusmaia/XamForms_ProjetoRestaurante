using System;
using Xamarin.Forms;

namespace VFood.CustomViews
{
    public enum ReturnType
    {
        Go,
        Next,
        Done,
        Send,
        Search
    }

    public class CustomEntry : Entry
    {
        public static readonly BindableProperty ReturnTypeProperty = BindableProperty.Create(nameof(ReturnType), typeof(ReturnType), typeof(CustomEntry), ReturnType.Done, BindingMode.OneWay);
        public ReturnType ReturnType
        {
            get { return (ReturnType)GetValue(ReturnTypeProperty); }
            set { SetValue(ReturnTypeProperty, value); }
        }

        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create(nameof(MaxLength), typeof(int?), typeof(FloatingActionButtonView), null);
        public int? MaxLength
        {
            get { return (int?)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }

        public new event EventHandler Completed;

        public void InvokeCompleted()
        {
            if (this.Completed != null)
                this.Completed.Invoke(this, null);
        }
    }
}
