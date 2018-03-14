using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Windows.Input;
using VFood.Modelo;
using VFood.Service;

namespace VFood.ViewModels
{
    public class EntregadorEditViewModel : ViewModelBase
    {
        private EntregadorService _entregadorService;

        private Entregador _entregador;
        public Entregador Entregador
        {
            get { return _entregador; }
            set { SetProperty(ref _entregador, value); }
        }

        private ICommand _salvarCommand;
        public ICommand SalvarCommand
        {
            get
            {
                if (_salvarCommand == null)
                {
                    _salvarCommand = new DelegateCommand(() =>
                    {
                        _entregadorService.Salva(Entregador);
                        var parameters = new NavigationParameters();
                        parameters.Add("reload", true);
                        NavigationService.GoBackAsync(parameters);
                    });
                }

                return _salvarCommand;
            }
        }

        public EntregadorEditViewModel(INavigationService navigationService) : base (navigationService)
        {
            Entregador = new Entregador();
            _entregadorService = new EntregadorService();
            Title = "Entregador";
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters != null && parameters.ContainsKey("entregador"))
            {
                Entregador = parameters["entregador"] as Entregador;
            }
        }
    }
}
