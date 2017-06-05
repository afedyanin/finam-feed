namespace FinamFeed.Metadata.Tests
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using FinamFeed.Metadata.Helpers;
    using NUnit.Framework;

    [TestFixture(Category = "Web"), Explicit]
    public class MetadataUpdaterTests
    {
        private const string CONST_SymbolsFeedUrl = "http://www.finam.ru/cache/icharts/icharts.js";
        private const string CONST_MarketsFeedUrl = "https://www.finam.ru/profile/moex-akcii/sberbank/export/";

        private WebRequestor requestor;
        private MetadataUpdater updater;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            this.requestor = new WebRequestor(new HttpClient());
        }

        [SetUp]
        public void Setup()
        {
            this.updater = new MetadataUpdater(this.requestor, CONST_MarketsFeedUrl, CONST_SymbolsFeedUrl);
        }

        [Test]
        public async Task CanLoadSymbolsFromWeb()
        {
            var symbols = await this.updater.LoadSymbols().ConfigureAwait(false);
            Assert.True(symbols.Count > 0);

            foreach (var symbol in symbols)
            {
#if DEBUG
                Console.WriteLine(symbol.ToJson());
#endif
                Assert.NotNull(symbol.Code); // may be empty 
                Assert.False(symbol.Id == 0);
                Assert.False(symbol.MarketId == 0);
                Assert.False(string.IsNullOrEmpty(symbol.Name));
            }
        }

        [Test]
        public async Task CanLoadMarketsFromWeb()
        {
            var markets = await this.updater.LoadMarkets().ConfigureAwait(false);
            Assert.True(markets.Count > 0);

            foreach(var market in markets)
            {
#if DEBUG
                Console.WriteLine(market.ToJson());
#endif
                Assert.True(market.Id != 0);
                Assert.False(string.IsNullOrEmpty(market.Name));
            }
        }
    }
}
