using System.Diagnostics;
using VFood.ViewModels;
using Xamarin.Forms;

namespace VFood.Views
{
    public partial class Clientes : ContentPage
    {
        public Clientes()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.iOS)
            {
                var viewModel = BindingContext as ClientesViewModel;

                var adicionarToolbarItem = new ToolbarItem();
                adicionarToolbarItem.Text = "Add";
                adicionarToolbarItem.Command = viewModel.AdicionarCommand;

                ToolbarItems.Add(adicionarToolbarItem);
            }
        }
    }
}
