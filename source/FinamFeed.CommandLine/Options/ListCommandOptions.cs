namespace FinamFeed.CommandLine.Options
{
    using global::CommandLine;

    [Verb("list", HelpText = "List all metadata info: markets or symbols.")]
    public class ListCommandOptions
    {
        [Option('m', "markets", HelpText = "List of all markets.")]
        public bool Markets { get; set; }

        [Option('s', "symbols", HelpText = "List of all symbols.")]
        public bool Symbols { get; set; }

        public bool IsValid()
        {
            return this.Markets || this.Symbols;
        }
    }
}
