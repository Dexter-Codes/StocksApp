using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Windows.Input;
using Microcharts;
using Newtonsoft.Json;
using Prism.Navigation;
using Prism.Services;
using SkiaSharp;
using StocksApp.Controls;
using StocksApp.Helpers;
using StocksApp.Model;
using StocksApp.Services;
using Xamarin.Forms;
using Chart = Microcharts.Chart;
using Entry = Microcharts.ChartEntry;

namespace StocksApp.ViewModel
{
    public class StockDetailPageViewModel : ViewModelBase
    {
        IPageDialogService _dialogService;

        INavigationService _navigationService;

        IStockService _stockService;

        StockDetails stockChart;

        PollingTimer timer;

        public ObservableCollection<Stocks> StocksList { get; set; }

        public ICommand ChartCommand { get; set; }

        public ICommand FilterCommand { get; set; }

        private Chart _goalsChart;
        public Chart GoalsChart
        {
            get => _goalsChart;
            set => SetProperty(ref _goalsChart, value);
        }

        public string ChartId { get; set; }

        public string FilterId { get; set; }

        public string IntervalVal { get; set; }

        public string StockName { get; set; }

        public StockDetailPageViewModel(INavigationService navigationService,
            IPageDialogService dialogService, IStockService stockService)
            : base(navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
            _stockService = stockService; ;
            StocksList = new ObservableCollection<Stocks>();
            ChartCommand = new Command(SelectChart);
            FilterCommand = new Command(SelectFilter);
            ChartId = "PointChart";
            FilterId = "1mo";
            IntervalVal = "1wk";
            timer = new PollingTimer(TimeSpan.FromMinutes(5), GetStockDetails);
        }

        private void SelectFilter(object obj)
        {
            var test = obj as Button;
            FilterId = test.Text;
            IntervalVal = DataConversion.GetRangeValue(FilterId);
            GetStockDetails();
        }

        private void SelectChart(object obj)
        {
            var test = obj as Button;
            ChartId = test.Text;
            PlotGraph(ChartId);
            ManageTextSizeInGraph();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var stocks = parameters.GetValue<string>("StockName");
            StockName = stocks;
            GetStockDetails();
            timer.Start();
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
            timer.Stop();
        }

        private async void GetStockDetails()
        {
            stockChart = new StockDetails();
            stockChart = await _stockService.GetStockDetails(StockName, IntervalVal, FilterId);
            CreatePlotableData(stockChart);
        }

        void CreatePlotableData(StockDetails root)
        {
            var data = root.chart.result;

            var time = data.FirstOrDefault().timestamp;
            var price = data.FirstOrDefault().indicators.quote;

            var chart = price.FirstOrDefault().low;

            GenerateData(time, chart);

        }

        void GenerateData(List<int> t, List<double> d)
        {
            List<Stocks> test = new List<Stocks>();
            for (int i = 0; i < t.Count; i++)
            {
                test.Add(new Stocks { Date = DataConversion.ConvertToDate(t[i]), Price = d[i] });
            }
            StocksList.Clear();
            StocksList.AddRange(test);

            PlotGraph(ChartId);
            ManageTextSizeInGraph();
        }

        void ManageTextSizeInGraph()
        {
             var dependency = DependencyService.Get<INativeFont>();
             GoalsChart.LabelTextSize = dependency.GetNativeSize(15);
        }

        void PlotGraph(string id)
        {           
            switch (id)
            {
                    case "PointChart":
                    GoalsChart = new PointChart()
                    {

                        Entries = this.StocksList.Select(x => new Entry((float)x.Price)
                        {
                            Color = GlobalValues.PinkColor,
                            TextColor = GlobalValues.PinkColor,
                            Label = FilterId=="1d"?x.Date.ToShortTimeString():x.Date.ToShortDateString(),
                            ValueLabel = x.Price.ToString("0.00"),
                        }) ?? new Entry[0],
                        PointMode = PointMode.Circle,
                        BackgroundColor = SKColors.Transparent,
                        ValueLabelOrientation = Orientation.Vertical
                    };
                    break;

                    case "LineChart":
                    GoalsChart = new LineChart()
                    {

                        Entries = this.StocksList.Select(x => new Entry((float)x.Price)
                        {
                            Color = GlobalValues.OrangeColor,
                            TextColor = GlobalValues.OrangeColor,
                            Label = FilterId == "1d" ? x.Date.ToShortTimeString() : x.Date.ToShortDateString(),
                            ValueLabel = x.Price.ToString("0.00"),
                        }) ?? new Entry[0],
                        LineMode = LineMode.Spline,
                        PointMode = PointMode.Circle,
                        LineSize = 15,
                        BackgroundColor = SKColors.Transparent,
                        ValueLabelOrientation = Orientation.Vertical
                    };
                    break;
            }
            
        }        
    }    

}
