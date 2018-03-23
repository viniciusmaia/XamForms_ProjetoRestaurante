using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Diagnostics;
using System.Windows.Input;
using VFood.Modelo;
using VFood.Service;
using VFood.Util.Dialogs;
using Xamarin.Forms;

namespace VFood.ViewModels
{
	public class ConfiguracaoViewModel : ViewModelBase
	{
        private ConfiguracaoDispositivoService _service;

        private ConfiguracaoDispositivo _configuracao;

        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _idDispositivo;
        public string IdDispositivo
        {
            get { return _idDispositivo; }
            set { SetProperty(ref _idDispositivo, value); }
        }

        private ICommand _obterIdCommand;
        public ICommand ObterIdCommand
        {
            get
            {
                if (_obterIdCommand == null)
                {
                    _obterIdCommand = new DelegateCommand(ExecuteObterIdCommand);
                }

                return _obterIdCommand;
            }
        }

        public ConfiguracaoViewModel(INavigationService navigationService) : base(navigationService)
        {
            _service = new ConfiguracaoDispositivoService();
            Title = "Configuração";
        }

        private async void ExecuteObterIdCommand()
        {
            if (Email != null)
            {
                var dialogCarregamento = DependencyService.Get<IDialogCarregamento>();

                try
                {
                    dialogCarregamento.Inicia("Aguarde", "Gerando Id do dispositivo", false);

                    _configuracao = await _service.ObtemIdDispositivo(Email);


                    IdDispositivo = _configuracao.IdLocal.ToString();
                    Email = _configuracao.Email;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    Debug.WriteLine(e.StackTrace);

                    var dialogInformacao = DependencyService.Get<IDialogInformacao>();
                    dialogInformacao.Abre("Erro", e.Message);
                }
                finally
                {
                    dialogCarregamento.Finaliza();
                }


            }
            else
            {
                var dialogInformacao = DependencyService.Get<IDialogInformacao>();
                dialogInformacao.Abre("Atenção!", "Preencha o campo \"E-mail\"");
            }

            
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            _configuracao = _service.GetConfiguracao();

            if (_configuracao != null)
            {
                IdDispositivo = _configuracao.IdLocal.ToString();
                Email = _configuracao.Email;
            }
            else
            {
                IdDispositivo = "Indefinido";
            }
            
        }
    }
}
