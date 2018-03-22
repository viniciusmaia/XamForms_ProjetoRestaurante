using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Diagnostics;
using System.Windows.Input;
using VFood.Modelo;
using VFood.Service;

namespace VFood.ViewModels
{
	public class ConfiguracaoViewModel : ViewModelBase
	{
        private ConfiguracaoDispositivoService _service;

        private ConfiguracaoDispositivo _configuracao;
        public ConfiguracaoDispositivo Configuracao
        {
            get { return _configuracao; }
            set { SetProperty(ref _configuracao, value); }
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
                    _obterIdCommand = new DelegateCommand(() =>
                    {

                    });
                }

                return _obterIdCommand;
            }
        }

        public ConfiguracaoViewModel(INavigationService navigationService) : base(navigationService)
        {
            _service = new ConfiguracaoDispositivoService();
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            try
            {
                Configuracao = _service.GetConfiguracao();

                if (Configuracao != null)
                {
                    IdDispositivo = Configuracao.Id.ToString();
                }
                else
                {
                    IdDispositivo = "Sem Id";
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);

                throw e;
            }

            
        }
    }
}
