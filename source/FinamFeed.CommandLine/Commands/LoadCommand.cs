namespace FinamFeed.CommandLine.Commands
{
    using System.IO;
    using System.Threading.Tasks;
    using FinamFeed.CommandLine.Options;

    public class LoadCommand : CommandBase<LoadCommandOptions>
    {
        public LoadCommand(LoadCommandOptions options, TextWriter output, TextWriter error) : base(options, output, error)
        {
        }

        protected override void ProcessInternal()
        {
            var symbol = this.FeedApi.Repository.GetSymbolById(this.Options.SymbolId);
            
            if (symbol == null)
            {
                this.Error.WriteLine($"ERROR: Cannot find symbol with id={this.Options.SymbolId}");
            }

            var sym = this.View.GetDisplaySymbolString(symbol, this.FeedApi.Repository.GetMarketsDictionary());
            this.Output.WriteLine($"symbol: [{sym}] period: {this.Options.Period} from: {this.Options.From.ToString("dd.MM.yyyy")} to: {this.Options.To.ToString("dd.MM.yyyy")} ");

            var data = this.FeedApi.LoadData(symbol, this.Options.Period, this.Options.From, this.Options.To).Result;

            if (string.IsNullOrWhiteSpace(data))
            {
                data = "No data found.";
            }

            this.Output.WriteLine(data);
        }

        public override bool ValidateOptions()
        {
            return base.ValidateOptions() ? this.Options.IsValid() : false;
        }

    }
}
