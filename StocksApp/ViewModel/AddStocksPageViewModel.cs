using System;
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
    public class AddStocksPageViewModel:ViewModelBase
    {
        INavigationService _navigationService;

        IPageDialogService _dialogService;

        IStockService _stockService; 

        public ICommand StocksSearchCommand { get; set; }

        public ICommand SelectCommand { get; set; }

        public ObservableCollection<Portfolio> StocksList { get; set; }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value);
        }

        public AddStocksPageViewModel(INavigationService navigationService,
            IPageDialogService dialogService, IStockService stockService) :base(navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
            _stockService = stockService;
            StocksList = new ObservableCollection<Portfolio>();
            StocksSearchCommand = new Command(OnStocksSearch);
            SelectCommand=new Command(OnSelect);
        }

        private async void OnSelect(object obj)
        {
            var stocks = obj as Portfolio;
            var navParameters = new NavigationParameters
            {
              {"Stocks",stocks},
              {"shortname", stocks.symbol}
            };

            if (Application.Current.Properties.ContainsKey("StockNames"))
            {
                string stock= Convert.ToString(Application.Current.Properties["StockNames"]);
                var appendStock = stock + "%2C" + stocks.symbol;
                Application.Current.Properties["StockNames"] = appendStock;
            }
            else
            {
                Application.Current.Properties["StockNames"] = stocks.symbol;
            }

            await _navigationService.GoBackAsync(navParameters);
            await _dialogService.DisplayAlertAsync("Added","Stocks added to watchlist successfully","OK");
        }

        private async void OnStocksSearch(object obj)
        {
            var text = obj as string;
            StockList stockWatch = new StockList();
            stockWatch = await _stockService.GetStockList(text);
            StocksList.AddRange(stockWatch.quotes);
        }
    }
}
