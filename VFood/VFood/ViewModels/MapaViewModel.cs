using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using VFood.Modelo;

namespace VFood.ViewModels
{
	public class MapaViewModel : ViewModelBase
	{
        public Func<Task> ExibeLocalizacaoCliente { get; set; }

        private Cliente _cliente;
        public Cliente Cliente
        {
            get { return _cliente; }
            set { SetProperty(ref _cliente, value); }
        }

        public MapaViewModel(INavigationService navigationService) : base(navigationService)
        {
            
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters != null && parameters.ContainsKey("cliente"))
            {
                Cliente = parameters["cliente"] as Cliente;
                ExibeLocalizacaoCliente();
            }
            else
            {
                throw new Exception("Informe o cliente");
            }
        }
    }
}
