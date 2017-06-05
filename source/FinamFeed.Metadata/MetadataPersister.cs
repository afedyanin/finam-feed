namespace FinamFeed.Metadata
{
    using System.Collections.Generic;
    using FinamFeed.Metadata.Helpers;
    using FinamFeed.Model.Entities;

    public class MetadataPersister
    {
        private string marketsFilePath;
        private string symbolsFilePath;

        public MetadataPersister(string marketsFilePath, string symbolsFilePath)
        {
            this.marketsFilePath = marketsFilePath;
            this.symbolsFilePath = symbolsFilePath;
        }

        public void SaveMarkets(IList<Market> markets)
        {
            FileHelper.PersistToJsonFile(markets, this.marketsFilePath);
        }
        public void SaveSymbols(IList<Symbol> symbols)
        {
            FileHelper.PersistToJsonFile(symbols, this.symbolsFilePath);
        }
        public IList<Market> LoadMarkets()
        {
            return FileHelper.LoadFromJsonFile<IList<Market>>(this.marketsFilePath);
        }
        public IList<Symbol> LoadSymbols()
        {
            return FileHelper.LoadFromJsonFile<IList<Symbol>>(this.symbolsFilePath);
        }
    }
}
