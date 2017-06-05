namespace FinamFeed.Metadata.Tests.Parsers
{
    using System;
    using System.Threading.Tasks;
    using FinamFeed.Metadata.Helpers;
    using FinamFeed.Metadata.Parsers;
    using NUnit.Framework;

    [TestFixture]
    public class MarketParserTests
    {
        [Test]
        public async Task CanParseRawMarketString()
        {
            var rawString = await DataHelper.GetRawMarketsString().ConfigureAwait(false);
            var res = MarketParser.Parse(rawString);
            Assert.True(res.Count > 0);
        }

        [TestCase(@"Finam.IssuerProfile.Main.setMarkets([{ value: 200, title: 'МосБиржа топ'}, { value: 1, title: 'МосБиржа акции'}, { value: 14, title: 'МосБиржа фьючерсы'}]);")]
        public void CanExtractJsonArray(string source)
        {
            var res = source.GetJsonArrayString();
            Assert.IsNotEmpty(res);
            Assert.AreEqual(0, res.IndexOf('['));
            Assert.AreEqual(res.Length - 1, res.IndexOf(']'));

#if DEBUG
            Console.WriteLine(res);
#endif
        }

        [TestCase(@"Finam.IssuerProfile.Main.setMarkets([{ value: 200, title: 'МосБиржа топ'}, { value: 1, title: 'МосБиржа акции'}, { value: 14, title: 'МосБиржа фьючерсы'}]);")]
        public void CanCreateMarketsArray(string source)
        {
            var res = MarketParser.Parse(source);

            Assert.NotNull(res);
            Assert.AreEqual(3, res.Count);
            foreach (var market in res)
            {
                Assert.True(market.Id != 0);
                Assert.False(string.IsNullOrEmpty(market.Name));
#if DEBUG
                Console.WriteLine(market.ToJson());
#endif
            }
        }
    }
}
