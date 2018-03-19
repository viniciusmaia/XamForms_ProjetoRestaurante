using System.Collections.Generic;
using UIKit;
using VFood.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(CustomNavigationRenderer))]
namespace VFood.iOS.Renderers
{
    public class CustomNavigationRenderer : NavigationRenderer
    {

        public override void PushViewController(UIKit.UIViewController viewController, bool animated)
        {
            base.PushViewController(viewController, animated);

            var list = new List<UIBarButtonItem>();

            foreach (var item in TopViewController.NavigationItem.RightBarButtonItems)
            {
                if (!string.IsNullOrWhiteSpace(item.Title))
                {
                    switch (item.Title)
                    {
                        case "Add":
                            var addButton = new UIBarButtonItem(UIBarButtonSystemItem.Add)
                            {
                                Action = item.Action,
                                Target = item.Target
                            };

                            list.Add(addButton);

                            break;

                        case "Done":
                            var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done)
                            {
                                Action = item.Action,
                                Target = item.Target
                            };

                            list.Add(doneButton);

                            break;

                        case "Trash":
                            var trashButton = new UIBarButtonItem(UIBarButtonSystemItem.Trash)
                            {
                                Action = item.Action,
                                Target = item.Target
                            };

                            list.Add(trashButton);

                            break;
                    }
                }

                TopViewController.NavigationItem.RightBarButtonItems = list.ToArray();
            }
        }
    }
}