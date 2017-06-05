namespace FinamFeed.Metadata.Tests
{
    using System.Threading.Tasks;
    using NUnit.Framework;

    [TestFixture]
    public class MetadataPersisterTests
    {
        private const string CONST_SymbolsPath = @"JsonData\symbols.json";
        private const string CONST_MarketsPath = @"JsonData\markets.json";

        [Test]
        public async Task CanSaveAndLoadMarkets()
        {
            var markets = await DataHelper.GetMarketsFromRawDataFile().ConfigureAwait(false);
            var persister = new MetadataPersister(CONST_MarketsPath, CONST_SymbolsPath);

            persister.SaveMarkets(markets);
            var savedMarkets = persister.LoadMarkets();

            Assert.NotNull(savedMarkets);
            Assert.AreEqual(markets.Count, savedMarkets.Count);
        }

        [Test]
        public async Task CanSaveAndLoadSymbols()
        {
            var symbols = await DataHelper.GetSymbolsFromRawDataFile().ConfigureAwait(false);
            var persister = new MetadataPersister(CONST_MarketsPath, CONST_SymbolsPath);

            persister.SaveSymbols(symbols);
            var savedSymbols = persister.LoadSymbols();

            Assert.NotNull(savedSymbols);
            Assert.AreEqual(symbols.Count, savedSymbols.Count);
        }
    }
}
