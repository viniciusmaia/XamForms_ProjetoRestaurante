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
            try
            {
                TaskScheduler.UnobservedTaskException += (sender, e) =>
                {
                    Debug.WriteLine(e.Exception.ToString());
                };

                InitializeComponent();

                await NavigationService.NavigateAsync("Menu/Navigation/Entregadores");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
            }

           
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Menu>();            
            containerRegistry.RegisterForNavigation<Navigation>();
            containerRegistry.RegisterForNavigation<Entregadores>();
            containerRegistry.RegisterForNavigation<Garcons>();
            containerRegistry.RegisterForNavigation<EntregadorEdit>();
        }        
    }
}
