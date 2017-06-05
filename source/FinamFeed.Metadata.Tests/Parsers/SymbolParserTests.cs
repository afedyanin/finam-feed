namespace FinamFeed.Metadata.Tests.Parsers
{
    using System;
    using System.Threading.Tasks;
    using FinamFeed.Metadata.Helpers;
    using FinamFeed.Metadata.Parsers;
    using NUnit.Framework;

    [TestFixture]
    public class SymbolParserTests
    {
        [Test]
        public async Task CanParseRawSymbolsString()
        {
            var rawString = await DataHelper.GetRawSymbolsString().ConfigureAwait(false);
            var symbols = SymbolParser.Parse(rawString);
            Assert.True(symbols.Count > 0);

            foreach (var symbol in symbols)
            {
#if DEBUG
                Console.WriteLine(symbol.ToJson());
#endif
                Assert.NotNull(symbol.Code); // may be empty 
                Assert.False(symbol.Id == 0);
                Assert.False(string.IsNullOrEmpty(symbol.Name));
                Assert.False(symbol.MarketId == 0);
            }
        }

        [Test]
        public void ParseNullStringReturnsEmptyList()
        {
            var res = SymbolParser.Parse(null);
            Assert.AreEqual(0, res.Count);
        }

        [Test]
        public void ParseEmptyStringReturnsEmptyList()
        {
            var res = SymbolParser.Parse(string.Empty);
            Assert.AreEqual(0, res.Count);
        }
    }
}
