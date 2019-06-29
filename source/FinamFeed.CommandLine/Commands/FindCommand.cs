namespace FinamFeed.CommandLine.Commands
{
    using System.IO;
    using FinamFeed.CommandLine.Options;

    public class FindCommand : CommandBase<FindCommandOptions>
    {
        public FindCommand(FindCommandOptions options, TextWriter output, TextWriter error) : base(options, output, error)
        {
        }

        protected override void ProcessInternal()
        {
            if (!string.IsNullOrWhiteSpace(this.Options.Ticker))
            {
                var symbols = this.FeedApi.Repository.FindSymbolByCode(this.Options.Ticker, this.Options.Strict);
                this.View.DisplaySymbols(symbols, this.FeedApi.Repository.GetMarketsDictionary());
            }
            else if (!string.IsNullOrWhiteSpace(this.Options.Name))
            {
                var symbols = this.FeedApi.Repository.FindSymbolByName(this.Options.Name, this.Options.Strict);
                this.View.DisplaySymbols(symbols, this.FeedApi.Repository.GetMarketsDictionary());
            }
        }

        public override bool ValidateOptions()
        {
            return base.ValidateOptions() ? this.Options.IsValid() : false;
        }
    }
}
