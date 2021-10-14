using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StocksApp.Helpers;
using StocksApp.Model;

namespace StocksApp.Services
{
    public class StockService : IStockService
    {
        public async Task<StockDetails> GetStockDetails(string symbol, string interval, string range)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://yh-finance.p.rapidapi.com/market/get-charts?symbol={symbol}&interval={interval}&range={range}"),
                Headers =
                {
                    { "x-rapidapi-host", GlobalValues.RAPIDAPIHOST },
                    { "x-rapidapi-key", GlobalValues.RAPIDAPIKEY },
                },
            };

            StockDetails stock = new StockDetails();
            try
            {
                var response = await client.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                    stock = JsonConvert.DeserializeObject<StockDetails>(body);
                    return stock;
                }
            }
            catch (Exception ex)
            {

            }

            return stock;
        }

        public async Task<StockList> GetStockList(string text)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://yh-finance.p.rapidapi.com/auto-complete?q={text}&region=US"),
                Headers =
                {
                    { "x-rapidapi-host", GlobalValues.RAPIDAPIHOST },
                    { "x-rapidapi-key", GlobalValues.RAPIDAPIKEY },
                },
            };

             StockList stockList = new StockList();
             var response = await client.SendAsync(request);
             if(response.StatusCode == HttpStatusCode.OK)
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    stockList = JsonConvert.DeserializeObject<StockList>(body);
                    Console.WriteLine(body);
                    return stockList;
                }

            return stockList;
        }

        public async Task<WatchList> GetWatchListUpdates(string symbol)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://yh-finance.p.rapidapi.com/market/v2/get-quotes?region=US&symbols={symbol}"),
                Headers =
                {
                    { "x-rapidapi-host", GlobalValues.RAPIDAPIHOST },
                    { "x-rapidapi-key", GlobalValues.RAPIDAPIKEY },
                },
            };

            WatchList watchList = new WatchList();
            try
            {
            
                var response = await client.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    watchList = JsonConvert.DeserializeObject<WatchList>(body);
                    return watchList;
                }
            }
            catch (Exception ex)
            {

            }
            return watchList;
        }
    }
}
