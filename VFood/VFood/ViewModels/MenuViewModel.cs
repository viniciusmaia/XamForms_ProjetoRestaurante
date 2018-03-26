using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VFood.ViewModels
{
	public class MenuViewModel : ViewModelBase
    {
        private DelegateCommand _entregadoresCommand;
        public DelegateCommand EntregadoresCommand
        {
            get
            {
                if (_entregadoresCommand == null)
                {
                    _entregadoresCommand = new DelegateCommand(() =>
                    {
                        NavigationService.NavigateAsync("Menu/Navigation/Entregadores");
                    });
                }

                return _entregadoresCommand;
            }
        }

        private DelegateCommand _clientesCommand;
        public DelegateCommand ClientesCommand
        {
            get
            {
                if (_clientesCommand == null)
                {
                    _clientesCommand = new DelegateCommand(() =>
                    {
                        NavigationService.NavigateAsync("Menu/Navigation/Clientes");
                    });
                }

                return _clientesCommand;
            }
        }

        private DelegateCommand _localizacaoClientesCommand;
        public DelegateCommand LocalizacaoClientesCommand
        {
            get
            {
                if (_localizacaoClientesCommand == null)
                {
                    _localizacaoClientesCommand = new DelegateCommand(() =>
                    {
                        NavigationService.NavigateAsync("Menu/Navigation/LocalizacaoCliente");
                    });
                }

                return _localizacaoClientesCommand;
            }
        }

        private DelegateCommand _tipoItensCardapioCommand;
        public DelegateCommand TipoItensCardapioCommand
        {
            get
            {
                if (_tipoItensCardapioCommand == null)
                {
                    _tipoItensCardapioCommand = new DelegateCommand(() =>
                    {
                        NavigationService.NavigateAsync("Menu/Navigation/TipoItensCardapio");
                    });
                }

                return _tipoItensCardapioCommand;
            }
        }

        private DelegateCommand _configuracaoCommand;
        public DelegateCommand ConfiguracaoCommand
        {
            get
            {
                if (_configuracaoCommand == null)
                {
                    _configuracaoCommand = new DelegateCommand(() =>
                    {
                        NavigationService.NavigateAsync("Menu/Navigation/Configuracao");
                    });
                }

                return _configuracaoCommand;
            }
        }

        public MenuViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Menu";
        }
    }
}
