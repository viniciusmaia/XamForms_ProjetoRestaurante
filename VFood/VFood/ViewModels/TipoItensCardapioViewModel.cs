using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
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
                    _tipoItemCardapioSelectCommand = new DelegateCommand<TipoItemCardapio>((itemCardapio) =>
                    {
                        var navigationParemeter = new NavigationParameters();
                        navigationParemeter.Add("itemCardapio", itemCardapio);

                        NavigationService.NavigateAsync("TipoItemCardapioEdit", navigationParemeter);
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
        }


	}
}
