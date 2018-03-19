using CoreGraphics;
using UIKit;
using VFood.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ListView), typeof(NoEmptyRowsTableViewRenderer))]
namespace VFood.iOS.Renderers
{
    public class NoEmptyRowsTableViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.TableFooterView = new UIView(CGRect.Empty);
            }
        }
    }
}