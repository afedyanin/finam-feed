namespace FinamFeed.Metadata
{
    using System;
    using FinamFeed.Metadata.Helpers;
    using FinamFeed.Model.Enums;

    public class Query
    {
        private readonly NameValueCodec codec;
        private string fileName;

        public Uri GetUrl(string hostUrl)
        {
            var query = this.codec.Encode();
            var urlString = $"{hostUrl}/{this.fileName}?{query}";
            return new Uri(urlString);
        }

        public Query()
        {
            this.fileName = $"table{FileExtension.Csv.Value}";
            this.codec = new NameValueCodec();
            this.codec.Add("apply", "0");
            this.codec.Add("MSOR", "0");        // 0 - open bar time, 1 - close bar time
            this.codec.Add("mstime", "on");     // Moscow time
            this.codec.Add("mstimever", "1");
        }

        public void AddMarket(int market)
        {
            this.codec.Add("market", market.ToString());
        }

        public void AddTicker(int id, string code)
        {
            this.codec.Add("em", id.ToString());
            this.codec.Add("code", code);
            this.codec.Add("cn", code);
        }

        public void AddDateFrom(DateTime date)
        {
            this.codec.Add("df", date.Day.ToString());
            this.codec.Add("mf", (date.Month - 1).ToString());
            this.codec.Add("yf", date.Year.ToString());
            this.codec.Add("from", date.ToString("dd.MM.yyyy"));
        }

        public void AddDateTo(DateTime date)
        {
            this.codec.Add("dt", date.Day.ToString());
            this.codec.Add("mt", (date.Month - 1).ToString());
            this.codec.Add("yt", date.Year.ToString());
            this.codec.Add("to", date.ToString("dd.MM.yyyy"));
        }

        public void AddFileName(string name, FileExtension extension)
        {
            this.codec.Add("f", name);
            this.codec.Add("e", extension.Value);
            this.fileName = $"{name}{extension.Value}";
        }

        public void AddPeriod(Period period)
        {
            var periodString = ((int)period).ToString();
            this.codec.Add("p", periodString);
        }

        public void AddDateFormat(DateFormat format)
        {
            var formatString = ((int)format).ToString();
            this.codec.Add("dtf", formatString);
        }

        public void AddTimeFormat(TimeFormat format)
        {
            var formatString = ((int)format).ToString();
            this.codec.Add("tmf", formatString);
        }

        public void AddFieldSeparator(FieldSeparator fieldSeparator)
        {
            var sepString = ((int)fieldSeparator).ToString();
            this.codec.Add("sep", sepString);
        }
        public void AddDecimalSeparator(DecimalSeparator decimalSeparator)
        {
            var sepString = ((int)decimalSeparator).ToString();
            this.codec.Add("sep2", sepString);
        }

        public void AddDataFormat(DataFormat dataFormat)
        {
            var formatString = ((int)dataFormat).ToString();
            this.codec.Add("datf", formatString);
        }

        public void AddHeader(bool addFileHeader)
        {
            var hString = addFileHeader ? "1" : "0";
            this.codec.Add("at", hString);
        }

        public void FillEmptyPeriods(bool fill)
        {
            var fString = fill ? "1" : "0";
            this.codec.Add("fsp", fString);
        }
    }
}
