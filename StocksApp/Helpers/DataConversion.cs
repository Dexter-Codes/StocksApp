using System;
namespace StocksApp.Helpers
{
    public static class DataConversion
    {
        public static DateTime ConvertToDate(int timeStamp)
        {
            var timeStamptoDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timeStamp).ToUniversalTime();

            return timeStamptoDateTime;
        }

        public static string GetRangeValue(string filter)
        {
            string interval = string.Empty;
            switch (filter)
            {
                case "1d":
                    interval = "15m";
                    break;
                case "5d":
                    interval = "1d";
                    break;
                case "3mo":
                    interval = "1wk";
                    break;
                case "6mo":
                    interval = "1wk";
                    break;
                case "1y":
                    interval = "1mo";
                    break;
            }
            return interval;
        }
    }
}
