using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Windows.Input;
using VFood.Modelo;
using VFood.Service;

namespace VFood.ViewModels
{
    public class EntregadorEditViewModel : ViewModelBase
    {
        private EntregadorService _entregadorService;

        public Action EscondeOpcaoRemover { get; set; }

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

        private ICommand _removeCommand;
        public ICommand RemoveCommand
        {
            get
            {
                if (_removeCommand == null)
                {
                    _removeCommand = new DelegateCommand(() =>
                    {
                        _entregadorService.Remove(Entregador);

                        var parameters = new NavigationParameters();
                        parameters.Add("reload", true);

                        NavigationService.GoBackAsync(parameters);
                    });
                }

                return _removeCommand;
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
            else
            {
                EscondeOpcaoRemover();
            }
        }
    }
}
