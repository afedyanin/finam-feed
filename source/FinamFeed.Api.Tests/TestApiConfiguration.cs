namespace FinamFeed.Api.Config
{
    public class TestApiConfiguration : IApiConfiguration
    {
        private const string CONST_SymbolsFeedUrl = "http://www.finam.ru/cache/icharts/icharts.js";
        private const string CONST_MarketsFeedUrl = "https://www.finam.ru/profile/moex-akcii/sberbank/export/";
        private const string CONST_FinamExportHost = "http://export.finam.ru";

        private const string CONST_SymbolsPath = @"JsonData\symbols.json";
        private const string CONST_MarketsPath = @"JsonData\markets.json";

        public string SymbolsFilePath => CONST_SymbolsPath;
        public string MarketsFilePath => CONST_MarketsPath;

        public string SymbolsFeedUrl => CONST_SymbolsFeedUrl;
        public string MarketsFeedUrl => CONST_MarketsFeedUrl;
        public string ExportDataUrl => CONST_FinamExportHost;
    }
}
