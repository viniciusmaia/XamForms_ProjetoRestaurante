using System.Diagnostics;
using Xamarin.Forms;

namespace VFood.Views
{
    public partial class Clientes : ContentPage
    {
        public Clientes()
        {
            try
            {
                InitializeComponent();
            }
            catch (System.Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
            }

        }
    }
}
