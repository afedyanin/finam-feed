namespace FinamFeed.Metadata.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FinamFeed.Metadata.Helpers;
    using FinamFeed.Model.Entities;
    using NUnit.Framework;

    [TestFixture]
    public class MetadataRepositoryTests
    {
        private MetadataRepository repository;
        private IList<Market> markets;
        private IList<Symbol> symbols;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            this.markets = await DataHelper.GetMarketsFromRawDataFile().ConfigureAwait(false);
            this.symbols = await DataHelper.GetSymbolsFromRawDataFile().ConfigureAwait(false);
            this.repository = new MetadataRepository(this.markets, this.symbols);
        }

        [Test]
        public void CanGetAllSymbols()
        {
            var allSymbols = this.repository.GetAllSymbols();
            Assert.True(allSymbols.Count > 0);
            Assert.AreEqual(this.symbols.Count, allSymbols.Count);
        }

        [Test]
        public void CanGetAllMarkets()
        {
            var allMarkets = this.repository.GetAllMarkets();
            Assert.True(allMarkets.Count > 0);
            Assert.AreEqual(this.markets.Count, allMarkets.Count);
        }

        [TestCase("Сбербанк")]
        [TestCase("СБЕРБАНК")]
        [TestCase("сБеРбАнК")]
        [TestCase("сбер")] 
        public void CanFindSymbolByName(string name)
        {
            var found = this.repository.FindSymbolByName(name);
            Assert.True(found.Count > 0);

            foreach (var s in found)
            {
                Assert.True(s.Name.ToUpper().Contains(name.ToUpper()));
#if DEBUG
                Console.WriteLine(s.ToJson());
#endif
            }
        }

        [TestCase("SBER")]
        [TestCase("sber")]
        [TestCase("Sber")]
        [TestCase("sBeR")]
        public void CanFindByCode(string code)
        {
            var found = this.repository.FindSymbolByCode(code);
            Assert.True(found.Count > 0);
            foreach (var s in found)
            {
                Assert.True(s.Code.ToUpper().Contains(code.ToUpper()));
#if DEBUG
                Console.WriteLine(s.ToJson());
#endif
            }
        }
    }
}
