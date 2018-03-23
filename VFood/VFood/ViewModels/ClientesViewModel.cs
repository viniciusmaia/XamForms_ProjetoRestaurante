using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using VFood.Modelo;
using VFood.Service;

namespace VFood.ViewModels
{
	public class ClientesViewModel : ViewModelBase
	{
        private ClienteService _service;

        private ObservableCollection<Cliente> _listaClientes;
        public ObservableCollection<Cliente> ListaClientes
        {
            get { return _listaClientes; }
            set { SetProperty(ref _listaClientes, value); }
        }

        private bool _isCarregando;
        public bool IsCarregando
        {
            get { return _isCarregando; }
            set { SetProperty(ref _isCarregando, value); }
        }

        private bool _canNavigate;
        public bool CanNavigate
        {
            get { return _canNavigate; }
            set { SetProperty(ref _canNavigate, value); }
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
                        NavigationService.NavigateAsync("ClienteEdit");
                    });
                }

                return _adicionarCommand;
            }
        }

        private DelegateCommand<Cliente> _clienteSelectCommand;
        public DelegateCommand<Cliente> ClienteSelectCommand
        {
            get
            {
                if (_clienteSelectCommand == null)
                {
                    _clienteSelectCommand = new DelegateCommand<Cliente>(async (cliente) =>
                    {
                        if (CanNavigate)
                        {
                            //Previnindo seleção de dois itens "simultaneamente".
                            CanNavigate = false;

                            var navigationParemeter = new NavigationParameters();
                            navigationParemeter.Add("cliente", cliente);

                            await NavigationService.NavigateAsync("ClienteEdit", navigationParemeter);

                            CanNavigate = true;
                        }

                    });
                }

                return _clienteSelectCommand;
            }
        }

        private DelegateCommand<Cliente> _removeCommand;
        public DelegateCommand<Cliente> RemoveCommand
        {
            get
            {
                if (_removeCommand == null)
                {
                    _removeCommand = new DelegateCommand<Cliente>((itemCardapio) =>
                    {
                        _service.Remove(itemCardapio);
                        ListaClientes.Remove(itemCardapio);
                    });
                }

                return _removeCommand;
            }
        }

        public ClientesViewModel(INavigationService navigationService) : base(navigationService)
        {
            _service = new ClienteService();
            ListaClientes = new ObservableCollection<Cliente>(_service.Listar());
            Title = "Clientes";
            CanNavigate = true;
        }

        public async override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters != null && parameters.ContainsKey("reload"))
            {
                IsCarregando = true;

                await Task.Run(() =>
                {
                    ListaClientes = new ObservableCollection<Cliente>(_service.Listar());
                });

                IsCarregando = false;
            }
        }
    }
}
