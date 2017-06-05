namespace FinamFeed.Metadata.Helpers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class WebRequestor
    {
        private HttpClient client;

        public WebRequestor(HttpClient client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls;
        }

        // TODO: Use cache control & e-tags
        public async Task<string> GetString(Uri url)
        {
            var response = await client.GetAsync(url).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var byteData = await client.GetByteArrayAsync(url).ConfigureAwait(false);
            return Encoding.GetEncoding(1251).GetString(byteData);
        }
    }
}
