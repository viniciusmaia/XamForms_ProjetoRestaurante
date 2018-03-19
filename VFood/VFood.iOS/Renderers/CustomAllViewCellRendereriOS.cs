using UIKit;
using VFood.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ViewCell), typeof(CustomAllViewCellRendereriOS))]
namespace VFood.iOS.Renderers
{
    public class CustomAllViewCellRendereriOS : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);

            if (cell != null)
            {
                cell.SelectionStyle = UIKit.UITableViewCellSelectionStyle.None;
            }

            return cell;
        }
    }
}