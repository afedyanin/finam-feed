namespace FinamFeed.Api.Config
{
    public interface IApiConfiguration
    {
        string SymbolsFilePath { get; }
        string MarketsFilePath { get; }

        string SymbolsFeedUrl { get; }
        string MarketsFeedUrl { get; }
        string ExportDataUrl { get; }
    }
}
