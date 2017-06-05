namespace FinamFeed.Metadata.Tests.Helpers
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using FinamFeed.Metadata.Helpers;
    using NUnit.Framework;

    [TestFixture(Category = "Web"), Explicit]
    public class WebRequestorTests
    {
        private HttpClient httpClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.httpClient = new HttpClient();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.httpClient.Dispose();
        }

        [Test]
        public async Task CanGetStringFromExternalSite()
        {
            var requestor = new WebRequestor(this.httpClient);
            var res = await requestor.GetString(new Uri("http://yandex.ru")).ConfigureAwait(false);
            Assert.IsNotEmpty(res);
        }

        [Test]
        public async Task CanGetStringFromFinamResource()
        {
            var requestor = new WebRequestor(this.httpClient);
            var res = await requestor.GetString(new Uri("https://www.finam.ru/cache/icharts/icharts.js")).ConfigureAwait(false);
#if DEBUG
            Console.WriteLine(res);
#endif
            Assert.IsNotEmpty(res);
        }
    }
}
