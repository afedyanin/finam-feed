namespace FinamFeed.Api
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    using FinamFeed.Api.Config;
    using FinamFeed.Metadata;
    using FinamFeed.Metadata.Helpers;
    using FinamFeed.Model.Entities;
    using FinamFeed.Model.Enums;

    public class FeedApi
    {
        private readonly IApiConfiguration config;
        private readonly MetadataPersister persister;

        public MetadataRepository Repository { get; private set; }

        public FeedApi(IApiConfiguration config)
        {
            this.config = config;
            this.persister = new MetadataPersister(this.config.MarketsFilePath, this.config.SymbolsFilePath);
            this.Repository = this.InitRepositorySafe();
        }

        public void Update()
        {
            using (var client = new HttpClient())
            {
                var requestor = new WebRequestor(client);
                var updater = new MetadataUpdater(requestor, config.MarketsFeedUrl, config.SymbolsFeedUrl);

                var markets = updater.LoadMarkets().Result;
                var symbols = updater.LoadSymbols().Result;

                this.persister.SaveMarkets(markets);
                this.persister.SaveSymbols(symbols);
            }
        }

        public async Task<string> LoadData(Symbol symbol, Period period, DateTime fromDate, DateTime toDate)
        {
            var requestUrl = new QueryBuilder()
                .WithDateRange(fromDate, toDate, period)
                .WithSymbol(symbol)
                .GetUrl(this.config.ExportDataUrl);

            using (var client = new HttpClient())
            {
                var requestor = new WebRequestor(client);
                return await requestor.GetString(requestUrl).ConfigureAwait(false);
            }
        }

        private MetadataRepository InitRepository()
        {
            var markets = this.persister.LoadMarkets();
            var symbols = this.persister.LoadSymbols();

            var res = new MetadataRepository(markets, symbols);
            return res;
        }

        private MetadataRepository InitRepositorySafe()
        {
            try
            {
                return this.InitRepository();
            }
            catch (Exception ex) when (ex is FileNotFoundException || ex is DirectoryNotFoundException)
            {
                this.Update();
                return this.InitRepository();
            }
        }
    }
}
