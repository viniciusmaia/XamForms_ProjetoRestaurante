using Xamarin.Forms;

namespace VFood.Views
{
    public partial class Entregadores : ContentPage
    {
        public Entregadores()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.Android)
            {
                ToolbarItems.Remove(ToolbarItemAdicionar);
            }
        }
    }
}
