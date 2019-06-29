namespace FinamFeed.CommandLine.Options
{
    using global::CommandLine;

    [Verb("find", HelpText = "Find symbol in metadata.")]
    public class FindCommandOptions
    {
        [Option('t', "ticker", HelpText = "Find symbol by ticker.")]
        public string Ticker { get; set; }

        [Option('n', "name", HelpText = "Find symbol by name.")]
        public string Name { get; set; }

        [Option('s', "strict", HelpText = "Strict (exact) search.")]
        public bool Strict{ get; set; }

        public bool IsValid()
        {
            return !(string.IsNullOrWhiteSpace(this.Ticker) && string.IsNullOrWhiteSpace(this.Name));
        }
    }
}
