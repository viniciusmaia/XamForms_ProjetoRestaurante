using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.Design.Widget;
using FormsPlugin.Iconize.Droid;
using ImageCircle.Forms.Plugin.Droid;
using Plugin.Iconize;
using Plugin.Iconize.Fonts;
using Plugin.Permissions;
using Prism;
using Prism.Ioc;

namespace VFood.Droid
{
    [Activity(Label = "VFood", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            Iconize.With(new FontAwesomeModule())
                   .With(new MaterialModule());
            IconControls.Init();

            ImageCircleRenderer.Init();

            LoadApplication(new App(new AndroidInitializer()));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            // Register any platform specific implementations
        }
    }
}

