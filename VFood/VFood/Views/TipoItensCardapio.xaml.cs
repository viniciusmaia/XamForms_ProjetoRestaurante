using VFood.ViewModels;
using Xamarin.Forms;

namespace VFood.Views
{
    public partial class TipoItensCardapio : ContentPage
    {
        public TipoItensCardapio()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.iOS)
            {
                var viewModel = BindingContext as TipoItensCardapioViewModel;

                var adicionarToolbarItem = new ToolbarItem();
                adicionarToolbarItem.Text = "Add";
                adicionarToolbarItem.Command = viewModel.AdicionarCommand;

                ToolbarItems.Add(adicionarToolbarItem);
            }
        }
    }
}
