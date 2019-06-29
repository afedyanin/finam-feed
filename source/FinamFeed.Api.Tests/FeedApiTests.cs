namespace FinamFeed.Api.Tests
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using FinamFeed.Api.Config;
    using NUnit.Framework;

    [TestFixture]
    public class FeedApiTests
    {
        private IApiConfiguration config;

        [SetUp]
        public void SetUp()
        {
            this.config = new TestApiConfiguration();
        }

        [Test]
        public void CanUpdateMetadata()
        {
            var feedApi = new FeedApi(this.config);
            feedApi.Update();

            Assert.True(IsFileExists(this.config.MarketsFilePath));
            Assert.True(IsFileExists(this.config.SymbolsFilePath));
        }

        [Test]
        public void CanGetAllMarkets()
        {
            var feedApi = new FeedApi(this.config);
            var allMarkets = feedApi.Repository.GetAllMarkets();
            Assert.True(allMarkets.Count > 0);
        }

        private static bool IsFileExists(string filePath)
        {
            var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
            return File.Exists(fullPath);
        }

    }
}
