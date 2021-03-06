using System;
using System.Collections.Generic;
using StocksApp.Services;

namespace StocksApp.Model
{
   
    public class Quarterly
    {
        public string date { get; set; }
        public double actual { get; set; }
        public double estimate { get; set; }
        public object revenue { get; set; }
        public Int64 earnings { get; set; }
    }

    public class EarningsChart
    {
        public List<Quarterly> quarterly { get; set; }
        public double currentQuarterEstimate { get; set; }
        public string currentQuarterEstimateDate { get; set; }
        public int currentQuarterEstimateYear { get; set; }
        public List<int> earningsDate { get; set; }
    }

    public class Yearly
    {
        public int date { get; set; }
        public object revenue { get; set; }
        public Int64 earnings { get; set; }
    }

    public class FinancialsChart
    {
        public List<Yearly> yearly { get; set; }
        public List<Quarterly> quarterly { get; set; }
    }

    public class Earnings
    {
        public int maxAge { get; set; }
        public EarningsChart earningsChart { get; set; }
        public FinancialsChart financialsChart { get; set; }
        public string financialCurrency { get; set; }
    }

    public class QuoteSummary
    {
        public Earnings earnings { get; set; }
    }

    public class PageViews
    {
        public string midTermTrend { get; set; }
        public string longTermTrend { get; set; }
        public string shortTermTrend { get; set; }
    }

    public class Resulted
    {
        public string language { get; set; }
        public string region { get; set; }
        public string quoteType { get; set; }
        public string quoteSourceName { get; set; }
        public bool triggerable { get; set; }
        public QuoteSummary quoteSummary { get; set; }
        public long firstTradeDateMilliseconds { get; set; }
        public int priceHint { get; set; }
        public double totalCash { get; set; }
        public int floatShares { get; set; }
        public long ebitda { get; set; }
        public double shortRatio { get; set; }
        public double preMarketChange { get; set; }
        public double preMarketChangePercent { get; set; }
        public int preMarketTime { get; set; }
        public double targetPriceHigh { get; set; }
        public double targetPriceLow { get; set; }
        public double targetPriceMean { get; set; }
        public double targetPriceMedian { get; set; }
        public double preMarketPrice { get; set; }
        public double heldPercentInsiders { get; set; }
        public string currency { get; set; }
        public List<string> components { get; set; }
        public double heldPercentInstitutions { get; set; }
        public double regularMarketChange { get; set; }
        public double regularMarketChangePercent { get; set; }
        public int regularMarketTime { get; set; }
        public double regularMarketPrice { get; set; }
        public double regularMarketDayHigh { get; set; }
        public string regularMarketDayRange { get; set; }
        public double regularMarketDayLow { get; set; }
        public int regularMarketVolume { get; set; }
        public int sharesShort { get; set; }
        public int sharesShortPrevMonth { get; set; }
        public double shortPercentFloat { get; set; }
        public double regularMarketPreviousClose { get; set; }
        public double bid { get; set; }
        public double ask { get; set; }
        public int bidSize { get; set; }
        public int askSize { get; set; }
        public string exchange { get; set; }
        public string market { get; set; }
        public string messageBoardId { get; set; }
        public string fullExchangeName { get; set; }
        public string shortName { get; set; }
        public string longName { get; set; }
        public double regularMarketOpen { get; set; }
        public int averageDailyVolume3Month { get; set; }
        public int averageDailyVolume10Day { get; set; }
        public double beta { get; set; }
        public double fiftyTwoWeekLowChange { get; set; }
        public double fiftyTwoWeekLowChangePercent { get; set; }
        public string fiftyTwoWeekRange { get; set; }
        public double fiftyTwoWeekHighChange { get; set; }
        public double fiftyTwoWeekHighChangePercent { get; set; }
        public double fiftyTwoWeekLow { get; set; }
        public double fiftyTwoWeekHigh { get; set; }
        public int earningsTimestamp { get; set; }
        public int earningsTimestampStart { get; set; }
        public int earningsTimestampEnd { get; set; }
        public double trailingPE { get; set; }
        public double pegRatio { get; set; }
        public double dividendsPerShare { get; set; }
        public double revenue { get; set; }
        public double priceToSales { get; set; }
        public string marketState { get; set; }
        public double epsTrailingTwelveMonths { get; set; }
        public double epsForward { get; set; }
        public double epsCurrentYear { get; set; }
        public double epsNextQuarter { get; set; }
        public double priceEpsCurrentYear { get; set; }
        public double priceEpsNextQuarter { get; set; }
        public int sharesOutstanding { get; set; }
        public double bookValue { get; set; }
        public double fiftyDayAverage { get; set; }
        public double fiftyDayAverageChange { get; set; }
        public double fiftyDayAverageChangePercent { get; set; }
        public double twoHundredDayAverage { get; set; }
        public double twoHundredDayAverageChange { get; set; }
        public double twoHundredDayAverageChangePercent { get; set; }
        public long marketCap { get; set; }
        public double forwardPE { get; set; }
        public double priceToBook { get; set; }
        public int sourceInterval { get; set; }
        public int exchangeDataDelayedBy { get; set; }
        public string exchangeTimezoneName { get; set; }
        public string exchangeTimezoneShortName { get; set; }
        public PageViews pageViews { get; set; }
        public int gmtOffSetMilliseconds { get; set; }
        public bool esgPopulated { get; set; }
        public bool tradeable { get; set; }
        public string symbol { get; set; }

        public string Price => $"{regularMarketPrice} $";
        public string MarketChange => $"{regularMarketChange} %";
    }

    public class QuoteResponse
    {
        public List<Resulted> result { get; set; }
        public object error { get; set; }
    }

    public class WatchList
    {
        public QuoteResponse quoteResponse { get; set; }
    }

}
