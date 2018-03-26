﻿using FormsPlugin.Iconize.iOS;
using Foundation;
using ImageCircle.Forms.Plugin.iOS;
using Plugin.Iconize;
using Plugin.Iconize.Fonts;
using Prism;
using Prism.Ioc;
using UIKit;


namespace VFood.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            UINavigationBar.Appearance.BarTintColor = UIColor.FromRGBA(188, 32, 38, 1);
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes { TextColor = UIColor.White });
            UINavigationBar.Appearance.TintColor = UIColor.White;
            UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);

            global::Xamarin.Forms.Forms.Init();
            global::Xamarin.FormsMaps.Init();
            Iconize.With(new FontAwesomeModule())
                   .With(new MaterialModule());
            IconControls.Init();
            ImageCircleRenderer.Init();

            var behaviors = new Prism.Behaviors.BehaviorBase<Xamarin.Forms.ListView>();

            LoadApplication(new App(new iOSInitializer()));

            return base.FinishedLaunching(app, options);
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {

        }
    }
}
