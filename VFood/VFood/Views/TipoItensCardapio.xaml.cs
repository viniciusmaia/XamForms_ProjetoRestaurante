using Xamarin.Forms;

namespace VFood.Views
{
    public partial class TipoItensCardapio : ContentPage
    {
        public TipoItensCardapio()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.Android)
            {
                ToolbarItems.Remove(ToolbarItemAdicionar);
            }
        }
    }
}
