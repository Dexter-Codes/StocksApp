using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows.Input;
using Newtonsoft.Json;
using Prism.Navigation;
using Prism.Services;
using StocksApp.Helpers;
using StocksApp.Model;
using StocksApp.Services;
using Xamarin.Forms;

namespace StocksApp.ViewModel
{
    public class HomePageViewModel: ViewModelBase
    {
        IPageDialogService _dialogService;

        INavigationService _navigationService;

        IStockService _stockService;

        public ICommand AddNewStockCommand { get; set; }

        public ICommand ViewCommand { get; set; }

        public ObservableCollection<Resulted> StocksList { get; set; }

        PollingTimer timer;

        WatchList marketChart;


        public HomePageViewModel(INavigationService navigationService,
            IPageDialogService dialogService, IStockService stockService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            _stockService = stockService;
            AddNewStockCommand = new Command(OnAddStock);
            ViewCommand = new Command(OnViewStock);
            StocksList = new ObservableCollection<Resulted>();
            timer = new PollingTimer(TimeSpan.FromMinutes(5), GetWatchListUpdates);
        }

        private async void OnViewStock(object obj)
        {
            var stocks = obj as Resulted;
            var navParameters = new NavigationParameters
            {
              {"StockName",stocks.symbol},
            };
            await _navigationService.NavigateAsync("StockDetailPage", navParameters);
        }

        private void OnAddStock(object obj)
        {
            _navigationService.NavigateAsync("AddStocksPage");
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.GetNavigationMode() == NavigationMode.New)
            {

            }
            else
            {
                var stocks = parameters.GetValue<Portfolio>("Stocks");
                if (stocks != null)
                {
                    GetWatchListUpdates();
                }
            }
            timer.Start();
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
            timer.Stop();
        }

        private async void GetWatchListUpdates()
        {
            if (Application.Current.Properties.ContainsKey("StockNames"))
            {
                string symbl = Convert.ToString(Application.Current.Properties["StockNames"]);
                var lists = await _stockService.GetWatchListUpdates(symbl);
                StocksList.Clear();
                StocksList.AddRange(lists.quoteResponse.result);
            }            
        }

    }
}
