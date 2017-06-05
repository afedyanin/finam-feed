namespace FinamFeed.CommandLine
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using FinamFeed.Model.Entities;

    public class ViewHelper
    {
        protected TextWriter Output { get; private set; }
        protected TextWriter Error { get; private set; }

        public ViewHelper(TextWriter output, TextWriter error)
        {
            this.Output = output;
            this.Error = error;
        }

        public void DisplayMarkets(IList<Market> markets)
        {
            if (markets == null || markets.Count == 0)
            {
                this.Output.WriteLine("Not found.");
                return;
            }

            foreach (var m in markets)
            {
                this.Output.WriteLine($"{m.Id,4} {m.Name,-35}");
            }
        }

        public void DisplaySymbols(IList<Symbol> symbols, IDictionary<int, Market> markets)
        {
            if (symbols == null || symbols.Count == 0)
            {
                this.Output.WriteLine("Not found.");
                return;
            }

            foreach (var s in symbols)
            {
                var marketName = GetMarketName(markets, s.MarketId);
                this.Output.WriteLine($"{s.Id, 7} {s.Code, -20} {s.Name, -55} {marketName, -35}");
            }
        }

        public string GetDisplaySymbolString(Symbol symbol, IDictionary<int, Market> markets)
        {
            var marketName = GetMarketName(markets, symbol.MarketId);
            return $"{symbol.Id} {symbol.Code} {symbol.Name} {marketName}";
        }

        private static string GetMarketName(IDictionary<int, Market> dict, int id)
        {
            if (dict.ContainsKey(id))
            {
                return dict[id].Name;
            }

            return string.Empty;
        }
    }
}
