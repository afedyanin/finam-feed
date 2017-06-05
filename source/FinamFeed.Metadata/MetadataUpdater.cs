namespace FinamFeed.Metadata
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FinamFeed.Metadata.Helpers;
    using FinamFeed.Metadata.Parsers;
    using FinamFeed.Model.Entities;

    public class MetadataUpdater
    {
        private WebRequestor requestor;
        private Uri symbolsFeedUrl;
        private Uri marketsFeedUrl;

        public MetadataUpdater(WebRequestor requestor, string marketsFeedUrl, string symbolsFeedUrl)
        {
            this.requestor = requestor;
            this.marketsFeedUrl = new Uri(marketsFeedUrl);
            this.symbolsFeedUrl = new Uri(symbolsFeedUrl);
        }

        public async Task<IList<Symbol>> LoadSymbols()
        {
            var data = await this.requestor.GetString(this.symbolsFeedUrl).ConfigureAwait(false);
            return SymbolParser.Parse(data);
        }

        public async Task<IList<Market>> LoadMarkets()
        {
            var data = await this.requestor.GetString(this.marketsFeedUrl).ConfigureAwait(false);
            return MarketParser.Parse(data);
        }
    }
}
