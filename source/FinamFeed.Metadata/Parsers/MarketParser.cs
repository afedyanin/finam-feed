namespace FinamFeed.Metadata.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FinamFeed.Metadata.Helpers;
    using FinamFeed.Model.Entities;
    using Newtonsoft.Json;

    public static class MarketParser
    {
        private const string CONST_MarketsKey = "Finam.IssuerProfile.Main.setMarkets(";

        public static IList<Market> Parse(string content)
        {
            var emptyRes = new List<Market>();

            if (string.IsNullOrWhiteSpace(content))
            {
                return emptyRes;
            }

            var marketString = GetMarketString(content);

            if (string.IsNullOrEmpty(marketString))
            {
                return emptyRes;
            }

            var jsonArrayString = marketString.GetJsonArrayString();
            var list = Enumerable.Empty<object>().Select(r => new { value = "", title = "" }).ToList();
            var protoMarkets = JsonConvert.DeserializeAnonymousType(jsonArrayString, list);

            var res = new List<Market>();

            foreach (var item in protoMarkets)
            {
                var market = new Market
                {
                    Id = item.value.GetInt(),
                    Name = item.title
                };

                if (market.Id == 0)
                {
                    // Ignore it
                    continue;
                }

                res.Add(market);
            }

            return res;
        }

        private static string GetMarketString(string content)
        {
            var lines = content.Split('\n');

            if (lines.Length <= 0)
            {
                return string.Empty;
            }

            return CommonParser.GetLineByKey(CONST_MarketsKey, lines);
        }
    }
}
