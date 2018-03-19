using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace VFood.CustomViews
{
    public enum FloatingActionButtonSize
    {
        Normal,
        Mini
    }

    public class FloatingActionButtonView : View
    {
        public static readonly BindableProperty ElevationProperty = BindableProperty.Create(nameof(Elevation), typeof(float), typeof(FloatingActionButtonView), 6.0f);
        public float Elevation
        {
            get { return (float)GetValue(ElevationProperty); }
            set { SetValue(ElevationProperty, value); }
        }

        public static readonly BindableProperty ImageNameProperty = BindableProperty.Create(nameof(ImageName), typeof(string), typeof(FloatingActionButtonView), string.Empty);
        public string ImageName
        {
            get { return (string)GetValue(ImageNameProperty); }
            set { SetValue(ImageNameProperty, value); }
        }
                
        public static readonly BindableProperty BackgroundTintProperty = BindableProperty.Create(nameof(BackgroundTint), typeof(Color), typeof(FloatingActionButtonView), Color.Accent);
        public Color BackgroundTint
        {
            get { return (Color)GetValue(BackgroundTintProperty); }
            set { SetValue(BackgroundTintProperty, value); }
        }
                
        public static readonly BindableProperty SizeProperty = BindableProperty.Create(nameof(Size), typeof(FloatingActionButtonSize), typeof(FloatingActionButtonView), FloatingActionButtonSize.Normal);
        public FloatingActionButtonSize Size
        {
            get { return (FloatingActionButtonSize)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(FloatingActionButtonView), null);
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public delegate void ShowHideDelegate();
        public delegate void AttachToListViewDelegate();

        public ShowHideDelegate Show { get; set; }
        public ShowHideDelegate Hide { get; set; }

        public event EventHandler Click;

        public void FloatingClicked()
        {
            var eventHandler = Click;
            eventHandler?.Invoke((object)this, EventArgs.Empty);
        }
    }
}
