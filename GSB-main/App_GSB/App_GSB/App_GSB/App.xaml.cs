using App_GSB.ViewModels;
using App_GSB.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace App_GSB
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/ConnexionPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ConnexionPage, ConnexionPageViewModel>();
            containerRegistry.RegisterForNavigation<AcceuilView, AcceuilViewModel>();
            containerRegistry.RegisterForNavigation<CompteRenduePage, CompteRendueViewModel>();
            containerRegistry.RegisterForNavigation<CreateCompteRenduePage, CreateCompteRendueViewModel>();
            containerRegistry.RegisterForNavigation<MedicamentPage, MedicamentViewModel>();
            containerRegistry.RegisterForNavigation<PraticienPage, PraticienViewModel>();
            containerRegistry.RegisterForNavigation<VisiteurPage, VisiteurViewModel>();
        }
    }
}
