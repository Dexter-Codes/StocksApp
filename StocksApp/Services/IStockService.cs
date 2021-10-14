using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StocksApp.Model;

namespace StocksApp.Services
{
    public interface IStockService
    {
        Task<WatchList> GetWatchListUpdates(string symbol);
        Task<StockDetails> GetStockDetails(string symbol,string interval,string range);
        Task<StockList> GetStockList(string text);
    }

    public interface IIdentifiable
    {
        string Id { get; set; }
    }
}
