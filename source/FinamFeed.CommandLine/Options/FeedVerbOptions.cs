namespace FinamFeed.CommandLine.Options
{
    using global::CommandLine;
    using global::CommandLine.Text;

    public class FeedVerbOptions 
    {
        [VerbOption("list", HelpText = "List all metadata info: markets or symbols.")]
        public ListCommandOptions ListVerb { get; set; }

        [VerbOption("find", HelpText = "Find symbol in metadata.")]
        public FindCommandOptions FindVerb { get; set; }

        [VerbOption("load", HelpText = "Load historical data from feed.")]
        public LoadCommandOptions LoadVerb { get; set; }

        [VerbOption("update", HelpText = "Update metadata info from web.")]
        public UpdateCommandOptions UpdateVerb { get; set; }

        [HelpVerbOption]
        public string GetUsage(string verb)
        {
            return HelpText.AutoBuild(this, verb);
        }
    }
}
