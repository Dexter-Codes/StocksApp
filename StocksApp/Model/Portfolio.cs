using System;
using System.Collections.Generic;

namespace StocksApp.Model
{
    public class Portfolio
    {
        public string exchange { get; set; }
        public string shortname { get; set; }
        public string quoteType { get; set; }
        public string symbol { get; set; }
        public string index { get; set; }
        public string score { get; set; }
        public string typeDisp { get; set; }
        public string longname { get; set; }
        public bool isYahooFinance { get; set; }

        public static implicit operator string(Portfolio v)
        {
            throw new NotImplementedException();
        }
    }

    public class StockList
    {
        public List<Portfolio> quotes { get; set; }
        public int count { get; set; }
    }

    public class Stocks
    {
        public DateTime Date { get; set; }
        public double Price { get; set; }
    }
}
