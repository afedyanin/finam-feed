namespace FinamFeed.Metadata
{
    using System;
    using FinamFeed.Model.Entities;
    using FinamFeed.Model.Enums;

    public class QueryBuilder
    {
        private readonly Query query;

        public QueryBuilder()
        {
            this.query = new Query();
            this.SetDefaultValues();
        }

        public Uri GetUrl(string hostUrl)
        {
            var baseUrl = hostUrl;
            return this.query.GetUrl(baseUrl);
        }

        public QueryBuilder WithDateRange(DateTime startDate, DateTime endDate, Period period)
        {
            this.query.AddDateFrom(startDate);
            this.query.AddDateTo(endDate);
            this.query.AddPeriod(period);
            return this;
        }

        public QueryBuilder WithSymbol(Symbol symbol)
        {
            this.query.AddMarket(symbol.MarketId);
            this.query.AddTicker(symbol.Id, symbol.Code);
            return this;
        }

        private void SetDefaultValues()
        {
            this.query.AddDataFormat(DataFormat.TPDTOHLCV);
            this.query.AddDateFormat(DateFormat.YYMMDD);
            this.query.AddTimeFormat(TimeFormat.HHMM);
            this.query.AddFieldSeparator(FieldSeparator.Comma);
            this.query.AddDecimalSeparator(DecimalSeparator.Dot);
            this.query.AddFileName("table", FileExtension.Csv);
            this.query.FillEmptyPeriods(false);
            this.query.AddHeader(true);
        }
    }
}
