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
        public Action<string, string, string> DisplayAlert;

        private Entregador _entregador;
        public Entregador Entregador
        {
            get { return _entregador; }
            set { SetProperty(ref _entregador, value); }
        }

        private bool _isNomeObrigatorioVisivel;
        public bool IsNomeObrigatorioVisivel
        {
            get { return _isNomeObrigatorioVisivel; }
            set { SetProperty(ref _isNomeObrigatorioVisivel, value); }
        }

        private bool _isTelefoneObrigatorioVisivel;
        public bool IsTelefoneObrigatorioVisivel
        {
            get { return _isTelefoneObrigatorioVisivel; }
            set { SetProperty(ref _isTelefoneObrigatorioVisivel, value); }
        }

        private ICommand _salvarCommand;
        public ICommand SalvarCommand
        {
            get
            {
                if (_salvarCommand == null)
                {
                    _salvarCommand = new DelegateCommand(ExecuteSalvarCommand);
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
            _entregadorService = new EntregadorService();
            Title = "Entregador";

            OcultaMensagensCampoObrigatorio();
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
                Entregador = new Entregador();
            }
        }

        private void ExecuteSalvarCommand()
        {
            OcultaMensagensCampoObrigatorio();

            if (CanSave())
            {
                _entregadorService.Salva(Entregador);
                var parameters = new NavigationParameters();
                parameters.Add("reload", true);
                NavigationService.GoBackAsync(parameters);
            }
        }

        private bool CanSave()
        {
            if (string.IsNullOrWhiteSpace(Entregador.Nome))
            {
                IsNomeObrigatorioVisivel = true;
            }
            if (string.IsNullOrWhiteSpace(Entregador.Telefone))
            {
                IsTelefoneObrigatorioVisivel = true;
            }

            if (IsNomeObrigatorioVisivel || IsTelefoneObrigatorioVisivel)
            {
                DisplayAlert("Erro", "Preencha os campos obrigatórios!", "Ok");

                return false;
            }

            return true;
        }

        private void OcultaMensagensCampoObrigatorio()
        {
            IsNomeObrigatorioVisivel = IsTelefoneObrigatorioVisivel = false;            
        }
    }
}
