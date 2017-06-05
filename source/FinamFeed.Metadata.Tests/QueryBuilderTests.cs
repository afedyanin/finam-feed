namespace FinamFeed.Metadata.Tests
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using FinamFeed.Metadata.Helpers;
    using FinamFeed.Model.Entities;
    using FinamFeed.Model.Enums;
    using NUnit.Framework;

    [TestFixture]
    public class QueryBuilderTests
    {
        private const string CONST_FinamExportHost = "http://export.finam.ru";

        [Test, Explicit]
        public async Task CanDownloadDataFromFinam()
        {
            // TODO: Refactor this: Load from Metadata Repo
            var sber = new Symbol()
            {
                MarketId = 8,
                Id = 81075,
                Code = "SBER"
            };

            var request = new QueryBuilder()
                .WithDateRange(new DateTime(2016, 01, 01), new DateTime(2016, 08, 31), Period.H1)
                .WithSymbol(sber)
                .GetUrl(CONST_FinamExportHost);

            using (var client = new HttpClient())
            {
                var requestor = new WebRequestor(client);
                var data = await requestor.GetString(request).ConfigureAwait(false);
                Console.WriteLine(data);
            }
        }
    }
}
