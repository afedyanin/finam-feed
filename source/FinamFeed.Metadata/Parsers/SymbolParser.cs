namespace FinamFeed.Metadata.Parsers
{
    using System.Collections.Generic;
    using System.Linq;
    using FinamFeed.Metadata.Helpers;
    using FinamFeed.Model.Entities;

    public static class SymbolParser
    {
        private const string CONST_IdsKey = "aEmitentIds";
        private const string CONST_NamesKey = "aEmitentNames";
        private const string CONST_CodesKey = "aEmitentCodes";
        private const string CONST_MarketsKey = "aEmitentMarkets";

        public static IList<Symbol> Parse(string symbolString)
        {
            var emptyRes = new List<Symbol>();

            if (string.IsNullOrWhiteSpace(symbolString))
            {
                return emptyRes;
            }

            var lines = symbolString.Split('\n');

            if (lines.Length < 4)
            {
                return emptyRes;
            }

            var ids = CommonParser.GetArrayValues(CommonParser.GetLineByKey(CONST_IdsKey, lines)).Split(',');
            var names = CommonParser.GetNames(CommonParser.GetArrayValues(CommonParser.GetLineByKey(CONST_NamesKey, lines)));
            var codes = CommonParser.GetArrayValues(CommonParser.GetLineByKey(CONST_CodesKey, lines)).Split(','); ;
            var markets = CommonParser.GetArrayValues(CommonParser.GetLineByKey(CONST_MarketsKey, lines)).Split(',');
            return BuildSymbols(ids, names, codes, markets);
        }

        private static IList<Symbol> BuildSymbols(string[] ids, string[] names, string[] codes, string[] markets)
        {
            var minIndex = (new int[] { ids?.Length ?? 0, names?.Length ?? 0, codes?.Length ?? 0, markets?.Length ?? 0 }).Min();

            var res = new List<Symbol>(minIndex);

            if (minIndex == 0)
            {
                return res;
            }

            for (var i = 0; i < minIndex; i++)
            {
                var symbol = new Symbol
                {
                    Id = ids[i].RemoveQuotes().GetInt(),
                    Code = codes[i].RemoveQuotes(),
                    Name = names[i].RemoveQuotes(),
                    MarketId = markets[i].GetInt()
                };

                if (symbol.Id == 0)
                {
                    // Ignore it
                    continue;
                }

                res.Add(symbol);
            }

            return res;
        }
    }
}
