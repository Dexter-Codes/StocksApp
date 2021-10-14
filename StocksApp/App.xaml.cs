using System;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using StocksApp.Services;
using StocksApp.View;
using StocksApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StocksApp
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override async void OnInitialized()
        {
            DevExpress.XamarinForms.Charts.Initializer.Init();
            InitializeComponent();
            NavigateToLogin();
        }

        private async void NavigateToLogin()
        {
            await NavigationService.NavigateAsync("NavigationPage/HomePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<AddStocksPage, AddStocksPageViewModel>();
            containerRegistry.RegisterForNavigation<StockDetailPage, StockDetailPageViewModel>();
            containerRegistry.Register<IStockService, StockService>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
