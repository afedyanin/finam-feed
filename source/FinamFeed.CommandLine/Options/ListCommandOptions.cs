namespace FinamFeed.CommandLine.Options
{
    using global::CommandLine;
    using global::CommandLine.Text;

    public class ListCommandOptions
    {
        [Option('m', "markets", HelpText = "List of all markets.")]
        public bool Markets { get; set; }

        [Option('s', "symbols", HelpText = "List of all symbols.")]
        public bool Symbols { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }

        public bool IsValid()
        {
            return this.Markets || this.Symbols;
        }
    }
}
