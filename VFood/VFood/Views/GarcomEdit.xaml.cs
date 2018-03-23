using VFood.ViewModels;
using Xamarin.Forms;

namespace VFood.Views
{
    public partial class GarcomEdit : ContentPage
    {
        public GarcomEdit()
        {
            InitializeComponent();

            var viewModel = BindingContext as GarcomEditViewModel;

            viewModel.ExibeOpcaoRemover = () =>
            {
                var removeItem = new ToolbarItem();
                removeItem.Command = viewModel.RemoverCommand;
                removeItem.Priority = 0;
                removeItem.Order = ToolbarItemOrder.Primary;

                if (Device.RuntimePlatform == Device.iOS)
                {
                    removeItem.Text = "Trash";
                }
                else
                {
                    removeItem.Icon = "ic_delete.png";
                }

                ToolbarItems.Add(removeItem);
            };
        }
    }
}
