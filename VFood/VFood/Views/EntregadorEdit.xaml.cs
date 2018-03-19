using VFood.ViewModels;
using Xamarin.Forms;

namespace VFood.Views
{
    public partial class EntregadorEdit : ContentPage
    {
        public EntregadorEdit()
        {
            InitializeComponent();

            var viewModel = BindingContext as EntregadorEditViewModel;

            viewModel.EscondeOpcaoRemover = () =>
            {                  
                ToolbarItems.Remove(RemoveItem);
            };

            viewModel.DisplayAlert = (titulo, mensagem, textoBotao) =>
            {
                DisplayAlert(titulo, mensagem, textoBotao);
            };
            
        }
    }
}
