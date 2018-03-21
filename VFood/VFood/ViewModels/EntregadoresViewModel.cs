using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using VFood.Modelo;
using VFood.Service;

namespace VFood.ViewModels
{
	public class EntregadoresViewModel : ViewModelBase, INavigationAware
	{

        private EntregadorService _entregadorService;

        private ObservableCollection<Entregador> _listaEntregadores;
        public ObservableCollection<Entregador> ListaEntregadores
        {
            get { return _listaEntregadores; }
            set { SetProperty(ref _listaEntregadores, value); }
        }

        private bool _isCarregando;
        public bool IsCarregando
        {
            get { return _isCarregando; }
            set { SetProperty(ref _isCarregando, value); }
        }

        private ICommand _adicionarCommand;
        public ICommand AdicionarCommand
        {
            get
            {
                if (_adicionarCommand == null)
                {
                    _adicionarCommand = new DelegateCommand(() =>
                    {
                       NavigationService.NavigateAsync("EntregadorEdit");
                    });
                }

                return _adicionarCommand;
            }
        }

        private DelegateCommand<Entregador> _entregadorSelectCommand;
        public DelegateCommand<Entregador> EntregadorSelectCommand
        {
            get
            {
                if (_entregadorSelectCommand == null)
                {
                    _entregadorSelectCommand = new DelegateCommand<Entregador>((entregador) =>
                    {
                        var navigationParemeter = new NavigationParameters();
                        navigationParemeter.Add("entregador", entregador);

                        NavigationService.NavigateAsync("EntregadorEdit", navigationParemeter);
                    });
                }

                return _entregadorSelectCommand;
            }
        }

        private DelegateCommand<Entregador> _removeCommand;
        public DelegateCommand<Entregador> RemoveCommand
        {
            get
            {
                if (_removeCommand == null)
                {
                    _removeCommand = new DelegateCommand<Entregador>((entregador) =>
                    {
                        _entregadorService.Remove(entregador);
                        ListaEntregadores.Remove(entregador);
                    });
                }

                return _removeCommand;
            }
        }

        public EntregadoresViewModel(INavigationService navigationService) : base(navigationService)
        {
            _entregadorService = new EntregadorService();
            ListaEntregadores = new ObservableCollection<Entregador>(_entregadorService.Listar());
            Title = "Entregadores";
        }

        public override async void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters != null && parameters.ContainsKey("reload"))
            {
                ListaEntregadores = null;
                IsCarregando = true;

                await Task.Run(() =>
                {
                    ListaEntregadores = new ObservableCollection<Entregador>(_entregadorService.Listar());
                });

                IsCarregando = false;
            }
        }
    }
}
