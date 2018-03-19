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



        private DelegateCommand _garconsCommand;
        public DelegateCommand GarconsCommand
        {
            get
            {
                if (_garconsCommand == null)
                {
                    _garconsCommand = new DelegateCommand(() =>
                    {
                        NavigationService.NavigateAsync("Menu/Navigation/Garcons");
                    });
                }

                return _garconsCommand;
            }
        }

        public MenuViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Menu";
        }
    }
}
