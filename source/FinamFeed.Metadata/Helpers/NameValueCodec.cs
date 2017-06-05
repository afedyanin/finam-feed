namespace FinamFeed.Metadata.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;

    internal class NameValueCodec
    {
        protected IDictionary<string, string> Items { get; set; }

        public NameValueCodec() : this(new Dictionary<string, string>())
        {
        }

        public NameValueCodec(IDictionary<string, string> initialDictionary)
        {
            this.Items = initialDictionary;
        }

        public static NameValueCodec FromEncodedString(string encodedString, char delimeter = '&')
        {
            var nameValueStrings = encodedString.Split(delimeter);

            var res = new NameValueCodec();

            foreach (var nameValue in nameValueStrings)
            {
                if (string.IsNullOrEmpty(nameValue))
                {
                    continue;
                }

                var nvArray = nameValue.Split('=');

                if (nvArray.Length < 2)
                {
                    continue;
                }

                res.Add(WebUtility.UrlDecode(nvArray[0]), WebUtility.UrlDecode(nvArray[1]));
            }

            return res;
        }

        public string Encode()
        {
            var sb = new StringBuilder();

            foreach (var key in this.Items.Keys)
            {
                var value = this.Items[key];

                if (string.IsNullOrEmpty(value))
                {
                    continue;
                }

                sb.AppendFormat("{0}={1}&", WebUtility.UrlEncode(key), WebUtility.UrlEncode(value));
            }

            return sb.ToString().TrimEnd('&');
        }

        public bool ContainsKey(string key)
        {
            return this.Items.ContainsKey(key);
        }

        public string Get(string key, string defaultValue = "")
        {
            var trimmedKey = string.IsNullOrEmpty(key) ? string.Empty : key.Trim();
            return this.ContainsKey(trimmedKey) ? this.Items[trimmedKey] : defaultValue;
        }

        public void Add(string key, string value, bool skipEmptyValue = false)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Key cannot be null or empty.", nameof(key));
            }

            if (skipEmptyValue && string.IsNullOrEmpty(value))
            {
                return;
            }

            if (this.ContainsKey(key))
            {
                this.Items[key] = value;
            }
            else
            {
                this.Items.Add(key, value);
            }
        }

        public IDictionary<string, string> GetItems()
        {
            return this.Items;
        }
    }
}
