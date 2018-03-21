using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using VFood.Modelo;
using VFood.Service;

namespace VFood.ViewModels
{
	public class TipoItensCardapioViewModel : ViewModelBase
	{
        private TipoItemCardapioService _service;

        private ObservableCollection<TipoItemCardapio> _listaItensCardapio;
        public ObservableCollection<TipoItemCardapio> ListaItensCardapio
        {
            get { return _listaItensCardapio; }
            set { SetProperty(ref _listaItensCardapio, value); }
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
                        NavigationService.NavigateAsync("TipoItemCardapioEdit");
                    });
                }

                return _adicionarCommand;
            }
        }

        private DelegateCommand<TipoItemCardapio> _tipoItemCardapioSelectCommand;
        public DelegateCommand<TipoItemCardapio> TipoItemCardapioSelectCommand
        {
            get
            {
                if (_tipoItemCardapioSelectCommand == null)
                {
                    _tipoItemCardapioSelectCommand = new DelegateCommand<TipoItemCardapio>(async (itemCardapio) =>
                    {
                        if (CanNavigate)
                        {
                            //Previnindo seleção de dois itens "simultaneamente".
                            CanNavigate = false;

                            var navigationParemeter = new NavigationParameters();
                            navigationParemeter.Add("itemCardapio", itemCardapio);

                            await NavigationService.NavigateAsync("TipoItemCardapioEdit", navigationParemeter);

                            CanNavigate = true;
                        }
                        
                    });
                }

                return _tipoItemCardapioSelectCommand;
            }
        }

        public TipoItensCardapioViewModel(INavigationService navigationService) : base(navigationService)
        {
            _service = new TipoItemCardapioService();
            ListaItensCardapio = new ObservableCollection<TipoItemCardapio>(_service.Listar());
            Title = "Cardápio";
            CanNavigate = true;
        }

        public async override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters != null && parameters.ContainsKey("reload"))
            {
                IsCarregando = true;

                await Task.Run(() =>
                {
                    ListaItensCardapio = new ObservableCollection<TipoItemCardapio>(_service.Listar());
                });

                IsCarregando = false;
            }
        }


    }
}
