using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VFood.Util.Dialogs;
using VFood.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace VFood.Views
{
    public partial class Mapa : ContentPage
    {
        public Mapa()
        {
            SolicitaPermissoes();
            InitializeComponent();

            var viewModel = BindingContext as MapaViewModel;

            viewModel.ExibeLocalizacaoCliente = ExibeLocalizacaoNoMapa;
        }

        private async void SolicitaPermissoes()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);

                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await DisplayAlert("Permissão necessária", "Esse aplicativo precisa da permissão de acesso a localização.", "Ok");
                    }

                    var resultado = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Location });
                    status = resultado[Permission.Location];
                }

                if (status == PermissionStatus.Granted)
                {
                    var resultado = await CrossGeolocator.Current.GetPositionAsync(new TimeSpan(10000L));                    
                }
                else if(status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Erro", "Não foi possível recuperar a localização, tente novamente.", "Ok");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);

                var dialogInformacao = DependencyService.Get<IDialogInformacao>();
                dialogInformacao.Abre(e.Message);
            }
        }

        protected async Task ExibeLocalizacaoNoMapa()
        {
            var viewModel = BindingContext as MapaViewModel;

            var geoCoder = new Geocoder();
            var posicao = await geoCoder.GetPositionsForAddressAsync(viewModel.Cliente.Endereco);
            MapaCliente.MoveToRegion(MapSpan.FromCenterAndRadius(posicao.First(), Distance.FromKilometers(0.3f)));

            var pin = new Pin()
            {
                Position = posicao.First(),
                Label = "Residência do Cliente",
                Address = viewModel.Cliente.Endereco
            };

            MapaCliente.Pins.Add(pin);
        }
    }
}
