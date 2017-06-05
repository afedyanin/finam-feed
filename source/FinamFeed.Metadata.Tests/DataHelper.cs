namespace FinamFeed.Metadata.Tests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FinamFeed.Metadata.Helpers;
    using FinamFeed.Metadata.Parsers;
    using FinamFeed.Model.Entities;

    internal static class DataHelper
    {
        private const string CONST_MarketsPath = @"TestData\MarketsSource.txt";
        private const string CONST_SymbolsPath = @"TestData\SymbolsSource.txt";

        public static async Task<string> GetRawMarketsString()
        {
            return await FileHelper.LoadString(CONST_MarketsPath).ConfigureAwait(false);
        }

        public static async Task<IList<Market>> GetMarketsFromRawDataFile()
        {
            var source = await GetRawMarketsString().ConfigureAwait(false);
            return MarketParser.Parse(source);
        }

        public static async Task<IList<Symbol>> GetSymbolsFromRawDataFile()
        {
            var source = await GetRawSymbolsString().ConfigureAwait(false);
            return SymbolParser.Parse(source);
        }

        public static async Task<string> GetRawSymbolsString()
        {
            return await FileHelper.LoadString(CONST_SymbolsPath).ConfigureAwait(false);
        }
    }
}
