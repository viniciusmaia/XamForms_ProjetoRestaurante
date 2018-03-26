using Plugin.Media;
using Plugin.Media.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.IO;
using System.Text;
using System.Windows.Input;
using VFood.Modelo;
using VFood.Service;
using VFood.Util;
using VFood.Util.Dialogs;
using Xamarin.Forms;

namespace VFood.ViewModels
{
	public class ClienteEditViewModel : ViewModelBase
    {
        private ClienteService _service;

        public Action ExibeOpcaoRemover { get; set; }

        private Cliente _cliente;
        public Cliente Cliente
        {
            get { return _cliente; }
            set { SetProperty(ref _cliente, value); }
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

        private bool _isEnderecoObrigatorioVisivel;
        public bool IsEnderecoObrigatorioVisivel
        {
            get { return _isEnderecoObrigatorioVisivel; }
            set { SetProperty(ref _isEnderecoObrigatorioVisivel, value); }
        }

        private bool _isNumeroObrigatorioVisivel;
        public bool IsNumeroObrigatorioVisivel
        {
            get { return _isNumeroObrigatorioVisivel; }
            set { SetProperty(ref _isNumeroObrigatorioVisivel, value); }
        }

        private bool _isBairroObrigatorioVisivel;
        public bool IsBairroObrigatorioVisivel
        {
            get { return _isBairroObrigatorioVisivel; }
            set { SetProperty(ref _isBairroObrigatorioVisivel, value); }
        }

        private bool _isCidadeObrigatorioVisivel;
        public bool IsCidadeObrigatorioVisivel
        {
            get { return _isCidadeObrigatorioVisivel; }
            set { SetProperty(ref _isCidadeObrigatorioVisivel, value); }
        }

        private bool _isEstadoObrigatorioVisivel;
        public bool IsEstadoObrigatorioVisivel
        {
            get { return _isEstadoObrigatorioVisivel; }
            set { SetProperty(ref _isEstadoObrigatorioVisivel, value); }
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

        private ICommand _removerCommand;
        public ICommand RemoverCommand
        {
            get
            {
                if (_removerCommand == null)
                {
                    _removerCommand = new DelegateCommand(ExecuteRemoverCommand);
                }

                return _removerCommand;
            }
        }


        public ClienteEditViewModel(INavigationService navigationService) : base(navigationService)
        {
            _service = new ClienteService();
            OcultaMensagensCamposObrigatorios();
            Title = "Cliente";
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters != null && parameters.ContainsKey("cliente"))
            {
                Cliente = parameters["cliente"] as Cliente;
                ExibeOpcaoRemover();
            }
            else
            {
                Cliente = new Cliente();
            }
        }

        private async void ExecuteSalvarCommand()
        {
            OcultaMensagensCamposObrigatorios();

            if (CanSalvar())
            {
                _service.Salva(Cliente);
                var parameters = new NavigationParameters();
                parameters.Add("reload", true);
                await NavigationService.GoBackAsync(parameters);
            }
        }

        private async void ExecuteRemoverCommand()
        {
            _service.Remove(Cliente);

            var parameters = new NavigationParameters();
            parameters.Add("reload", true);

            await NavigationService.GoBackAsync(parameters);
        }

        private bool CanSalvar()
        {
            var mensagemErroBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(Cliente.Nome))
            {
                IsNomeObrigatorioVisivel = true;
            }

            if (string.IsNullOrWhiteSpace(Cliente.Bairro))
            {
                IsBairroObrigatorioVisivel = true;
            }
            
            if (string.IsNullOrWhiteSpace(Cliente.Cidade))
            {
                IsCidadeObrigatorioVisivel = true;
            }

            if (string.IsNullOrWhiteSpace(Cliente.Endereco))
            {
                IsEnderecoObrigatorioVisivel = true;
            }

            if (string.IsNullOrWhiteSpace(Cliente.Estado))
            {
                IsEstadoObrigatorioVisivel = true;
            }

            if (string.IsNullOrWhiteSpace(Cliente.Numero))
            {
                IsNumeroObrigatorioVisivel = true;
            }

            if (string.IsNullOrWhiteSpace(Cliente.Telefone))
            {
                IsTelefoneObrigatorioVisivel = true;
            }


            var resultado = IsBairroObrigatorioVisivel || IsCidadeObrigatorioVisivel || IsEnderecoObrigatorioVisivel || IsEstadoObrigatorioVisivel ||
                            IsNomeObrigatorioVisivel || IsNumeroObrigatorioVisivel || IsTelefoneObrigatorioVisivel;

            if (resultado)
            {
                var informacaoDialog = DependencyService.Get<IDialogInformacao>();
                informacaoDialog.Abre("Atenção", "Preencha os campos obrigatórios!");

                return false;
            }

            return true;
        }

        private void OcultaMensagensCamposObrigatorios()
        {
            IsTelefoneObrigatorioVisivel = IsNomeObrigatorioVisivel = IsBairroObrigatorioVisivel = IsCidadeObrigatorioVisivel
                = IsEnderecoObrigatorioVisivel = IsEstadoObrigatorioVisivel = IsNumeroObrigatorioVisivel = false;
        }
    }
}
