using Prism;
using Prism.Ioc;
using VFood.Views;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using System;
using System.Threading.Tasks;
using System.Diagnostics;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace VFood
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("Menu/Navigation/Entregadores");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Menu>();            
            containerRegistry.RegisterForNavigation<Navigation>();
            containerRegistry.RegisterForNavigation<Entregadores>();
            containerRegistry.RegisterForNavigation<Garcons>();
            containerRegistry.RegisterForNavigation<EntregadorEdit>();
            containerRegistry.RegisterForNavigation<TipoItensCardapio>();
            containerRegistry.RegisterForNavigation<TipoItemCardapioEdit>();
        }        
    }
}
