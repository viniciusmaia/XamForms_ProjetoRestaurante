using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VFood.Modelo;

namespace VFood.ViewModels
{
	public class EntregadoresViewModel : ViewModelBase
	{

        private ObservableCollection<Entregador> _listaEntregadores;
        public ObservableCollection<Entregador> ListaEntregadores
        {
            get { return _listaEntregadores; }
            set { SetProperty(ref _listaEntregadores, value); }
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

        public EntregadoresViewModel(INavigationService navigationService) : base(navigationService)
        {
            ListaEntregadores = new ObservableCollection<Entregador>();
            ListaEntregadores.Add(new Entregador()
            {
                Nome = "Vinícius",
                Telefone = "3333-3333"
            });
        }
	}
}
