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
	public class GarconsViewModel : ViewModelBase
	{
        private GarcomService _service;

        private ObservableCollection<Garcom> _listaGarcons;
        public ObservableCollection<Garcom> ListaGarcons
        {
            get { return _listaGarcons; }
            set { SetProperty(ref _listaGarcons, value); }
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
                        NavigationService.NavigateAsync("GarcomEdit");
                    });
                }

                return _adicionarCommand;
            }
        }

        private DelegateCommand<Garcom> _garcomSelectCommand;
        public DelegateCommand<Garcom> GarcomSelectCommand
        {
            get
            {
                if (_garcomSelectCommand == null)
                {
                    _garcomSelectCommand = new DelegateCommand<Garcom>(async (garcom) =>
                    {
                        if (CanNavigate)
                        {
                            //Previnindo seleção de dois itens "simultaneamente".
                            CanNavigate = false;

                            var navigationParemeter = new NavigationParameters();
                            navigationParemeter.Add("garcom", garcom);

                            await NavigationService.NavigateAsync("GarcomEdit", navigationParemeter);

                            CanNavigate = true;
                        }

                    });
                }

                return _garcomSelectCommand;
            }
        }

        private DelegateCommand<Garcom> _removeCommand;
        public DelegateCommand<Garcom> RemoveCommand
        {
            get
            {
                if (_removeCommand == null)
                {
                    _removeCommand = new DelegateCommand<Garcom>((itemCardapio) =>
                    {
                        _service.Remove(itemCardapio);
                        ListaGarcons.Remove(itemCardapio);
                    });
                }

                return _removeCommand;
            }
        }

        public GarconsViewModel(INavigationService navigationService) : base(navigationService)
        {
            _service = new GarcomService();
            ListaGarcons = new ObservableCollection<Garcom>(_service.Listar());
            Title = "Garçons";
            CanNavigate = true;
        }

        public async override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters != null && parameters.ContainsKey("reload"))
            {
                IsCarregando = true;

                await Task.Run(() =>
                {
                    ListaGarcons = new ObservableCollection<Garcom>(_service.Listar());
                });

                IsCarregando = false;
            }
        }
    }
}
